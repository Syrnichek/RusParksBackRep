using Microsoft.EntityFrameworkCore;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services
{
    public class ParkManage :IParkManage
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
                return parks;
            }
        }

        public IQueryable<ParksModel> GetParksById(int parkid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<ParksModel> parksIQueryable = applicationContext.parks;
                var park = parksIQueryable.Where(p => p.parkid == parkid);
                return park;
            }
        }
    }
}