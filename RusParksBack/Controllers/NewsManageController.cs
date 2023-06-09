using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
    public class NewsManageController :Controller
    {
        private INewsManageService _newsManageService;
        
        public NewsManageController(INewsManageService newsManageService)
        {
            _newsManageService = newsManageService;
        }

        [HttpGet]
        [Route("api/newsManage/GetNewsAll")]
        public List<NewsModel> GetNewsAll()
        {
            return _newsManageService.GetNewsAll();
        } 
        
        [HttpGet]
        [Route("api/newsManage/GetNewsById")]
        public List<NewsModel> GetNewsById(int newsid)
        {
            return _newsManageService.GetNewsById(newsid);
        }  
    }
}