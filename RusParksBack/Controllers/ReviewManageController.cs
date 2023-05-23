using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
    public class ReviewManageController : Controller
    {
        private readonly IReviewManage _reviewManage;
        
        public ReviewManageController(IReviewManage reviewManage)
        {
            _reviewManage = reviewManage;
        }

        [HttpGet]
        [Route("api/reviewManage/ReviewAdd")]
        public void ReviewAdd(int parkid, int userid, int reviewscore, string reviewtext)
        {
            _reviewManage.ReviewAdd(parkid, userid, reviewscore, reviewtext);
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetAll")]
        public List<ReviewsModel> ReviewsGetAll()
        {
            return _reviewManage.ReviewsGetAll();
        }
        
        [HttpGet]
        [Route("api/reviewManage/ReviewsGetByParkId")]
        public List<ReviewsModel> ReviewsGetByParkId(int parkid)
        {
            return _reviewManage.ReviewsGetByParkId(parkid);
        }
    }
}