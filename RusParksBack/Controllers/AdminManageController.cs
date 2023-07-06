using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;

namespace RusParksBack.Controllers
{
    public class AdminManageController :Controller
    {
        private readonly IAdminManageService _adminManageService;

        public AdminManageController(IAdminManageService adminManageService)
        {
            _adminManageService = adminManageService;
        }
        
        [HttpGet]
        [Route("api/adminManage/ReviewDelete")]
        public IActionResult ReviewDelete(int reviewid)
        {
            try
            {
                _adminManageService.ReviewDelete(reviewid);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(420, "Отзыв отсутсвует");
            }
        }
        
        [HttpPost]
        [Route("api/adminManage/ParkAdd")]
        public IActionResult ParkAdd(string parkname, string parkcity, string parkmetro, IFormFile [] mainimages, string[] imagespath, string maintext, string enterinfotext, int[] typeid)
        {
                _adminManageService.ParkAdd
                    (
                    parkname,
                    parkcity, 
                    parkmetro, 
                    mainimages,
                    imagespath,
                    maintext,
                    enterinfotext,
                    typeid
                    );
                return Ok();
        }
        
        [HttpPost]
        [Route("api/adminManage/NewsAdd")]
        public IActionResult NewsAdd(string newstitle, string newsimagepath, IFormFile[] newsimage, string newstext)
        {
                _adminManageService.NewsAdd
                (
                    newstitle,
                    newsimagepath, 
                    newsimage,
                    newstext
                );
                return Ok();
            
        }
    }
}