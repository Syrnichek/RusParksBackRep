using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
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
        [Route("api/parkManage/GetParksById")]
        public List<ParksModel> GetParksById(int parkId)
        {
            return _parkManageService.GetParksById(parkId);
        }
        
        [HttpGet]
        [Route("api/parkManage/GetLandmarksByPark")]
        public List<LandmarksModel> GetLandmarksByPark(int parkId)
        {
            return _parkManageService.GetLandmarksByPark(parkId);
        }
    }
}