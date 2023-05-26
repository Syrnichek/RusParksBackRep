using Microsoft.EntityFrameworkCore;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services
{
    public class ParkManageService :IParkManageService
    {
        public List<ParksModel> GetParksAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IEnumerable<ParksModel> parksIEnumerable = applicationContext.parks;
                return parksIEnumerable.ToList();
            }
        }

        public List<ParksModel> GetParksByType(int type)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<ParksModel> parksIQueryable = applicationContext.parks;
                var parks = parksIQueryable.Where(p => p.typeid.Contains(type)).ToList();
                return parks.ToList();
            }
        }

        public List<ParksModel> GetParksById(int parkid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<ParksModel> parksIQueryable = applicationContext.parks;
                var park = parksIQueryable.Where(p => p.parkid == parkid);
                return park.ToList();
            }
        }

        public List<LandmarksModel> GetLandmarksByPark(int parkid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<LandmarksModel> landmarksIQueryable = applicationContext.landmarks;
                var landmarks = landmarksIQueryable.Where(l => l.parkid == parkid);
                return landmarks.ToList();
            }
        }
    }
}