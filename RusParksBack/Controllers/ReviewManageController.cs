using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
    public class ReviewManageController : Controller
    {
        private readonly IReviewManageService _reviewManageService;
        
        public ReviewManageController(IReviewManageService reviewManageService)
        {
            _reviewManageService = reviewManageService;
        }

        [HttpGet]
        [Route("api/reviewManage/ReviewAdd")]
        public void ReviewAdd(int parkid, int userid, int reviewscore, string reviewtext)
        {
            _reviewManageService.ReviewAdd(parkid, userid, reviewscore, reviewtext);
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetAll")]
        public List<ReviewsModel> ReviewsGetAll()
        {
            return _reviewManageService.ReviewsGetAll();
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetByParkId")]
        public List<ReviewsModel> ReviewsGetByParkId(int parkid)
        {
            return _reviewManageService.ReviewsGetByParkId(parkid);
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetAverage")]
        public double ReviewsGetAverage(int parkid)
        {
            return _reviewManageService.ReviewsGetAverage(parkid);
        }
    }
}