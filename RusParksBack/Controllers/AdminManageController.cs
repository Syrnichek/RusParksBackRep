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
        public IActionResult ParkAdd(string parkname, string parkcity, string parkmetro, string[] mainimages, string maintext, string enterinfotext, int[] typeid)
        {
            try
            {
                _adminManageService.ParkAdd
                    (
                    parkname,
                    parkcity, 
                    parkmetro, 
                    mainimages, 
                    maintext, 
                    enterinfotext,
                    typeid
                    );
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(421, "Ошибка при добавлении парка");
            }
        }
        
        [HttpPost]
        [Route("api/adminManage/NewsAdd")]
        public IActionResult NewsAdd(string newstitle, string newsimage, string newstext)
        {
            try
            {
                _adminManageService.NewsAdd
                (
                    newstitle,
                    newsimage, 
                    newstext
                );
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(422, "Ошибка при добавлении парка");
            }
        }
    }
}