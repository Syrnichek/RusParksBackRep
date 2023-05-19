using Microsoft.AspNetCore.Mvc;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Controllers
{
    public class ParkManageController :Controller
    {
        private readonly IParkManage _parkManage;
    
        public ParkManageController(IParkManage parkManage)
        {
            _parkManage = parkManage;
        }
    
        [HttpGet]
        [Route("api/parkManage/GetParksAll")]
        public List<ParksModel> GetParksAll()
        {
            return _parkManage.GetParksAll();
        }
    
        [HttpGet]
        [Route("api/parkManage/GetParksByType")]
        public List<ParksModel> GetParksByType(int type)
        {
            return _parkManage.GetParksByType(type);
        }
        
        [HttpGet]
        [Route("api/parkManage/GetParksById")]
        public IQueryable<ParksModel> GetParksById(int id)
        {
            return _parkManage.GetParksById(id);
        }
    }
}