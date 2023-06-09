using Microsoft.EntityFrameworkCore;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services
{
    public class NewsManageService :INewsManageService
    {
        public List<NewsModel> GetNewsAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IEnumerable<NewsModel> newsIEnumerable = applicationContext.news;
                return newsIEnumerable.ToList();
            }
        }

        public List<NewsModel> GetNewsById(int newsid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<NewsModel> newsIEnumerable = applicationContext.news;
                var news = newsIEnumerable.Where(n => n.newsid == newsid);
                return news.ToList();
            }
        }
    }
}