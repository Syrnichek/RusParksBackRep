using Microsoft.EntityFrameworkCore;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services
{
    public class AdminManageService: IAdminManageService
    {
        public void ReviewDelete(int reviewId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                ReviewsModel review = applicationContext.reviews.FirstOrDefault(r => r.reviewid == reviewId);
                if (review != null)
                {
                    applicationContext.reviews.Remove(review);
                    applicationContext.SaveChanges();
                }
            }
        }

        public void ParkAdd(string parkName, string parkCity, string parkMetro, string[] mainImages, string mainText, string enterInfoText)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                ParksModel park = new ParksModel
                {
                    parkname = parkName, 
                    parkcity = parkCity, 
                    parkmetro = parkMetro, 
                    mainimages = mainImages, 
                    maintext = mainText, 
                    enterinfotext = enterInfoText
                };

                applicationContext.parks.Add(park);
                applicationContext.SaveChanges();
            }
        }

        public void NewsAdd(string newsTitle, string newsImage, string newsText)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                NewsModel news = new NewsModel
                {
                    newstitle = newsTitle,
                    newsimage = newsImage,
                    newstext = newsText
                };

                applicationContext.news.Add(news);
                applicationContext.SaveChanges();
            }
        }
    }
}