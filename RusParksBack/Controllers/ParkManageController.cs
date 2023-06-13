using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
    [Authorize(Roles = "User")]
    public class ParkManageController :Controller
    {
        private readonly IParkManageService _parkManageService;
    
        public ParkManageController(IParkManageService parkManageService)
        {
            _parkManageService = parkManageService;
        }
    
        [HttpGet]
        [Route("api/parkManage/GetParksAll")]
        public List<ParksModel> GetParksAll()
        {
            return _parkManageService.GetParksAll();
        }
    
        [HttpGet]
        [Route("api/parkManage/GetParksByType")]
        public List<ParksModel> GetParksByType(int type)
        {
            return _parkManageService.GetParksByType(type);
        }
        
        [HttpGet]
        [Route("api/parkManage/GetParksById")]
        public List<ParksModel> GetParksById(int id)
        {
            return _parkManageService.GetParksById(id);
        }
        
        [HttpGet]
        [Route("api/parkManage/GetLandmarksByPark")]
        public List<LandmarksModel> GetLandmarksByPark(int id)
        {
            return _parkManageService.GetLandmarksByPark(id);
        }
    }
}