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
        public void ReviewAdd(int parkId, int userId, int reviewScore, string reviewText, string userLogin)
        {
            _reviewManageService.ReviewAdd(parkId, userId, reviewScore, reviewText, userLogin);
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetAll")]
        public List<ReviewsModel> ReviewsGetAll()
        {
            return _reviewManageService.ReviewsGetAll();
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetByParkId")]
        public List<ReviewsModel> ReviewsGetByParkId(int parkId)
        {
            return _reviewManageService.ReviewsGetByParkId(parkId);
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetAverage")]
        public double ReviewsGetAverage(int parkId)
        {
            return _reviewManageService.ReviewsGetAverage(parkId);
        }
    }
}