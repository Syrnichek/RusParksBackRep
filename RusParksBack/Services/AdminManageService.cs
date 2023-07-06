using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
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

        public void ParkAdd(string parkName, string parkCity, string parkMetro, IFormFile[] mainImages,
            string[] imagesPath, string mainText, string enterInfoText, int[] typeId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;
            
            foreach (var imageFile in mainImages)
            {
                string uploads = Path.Combine("StaticFiles/images");
                Directory.CreateDirectory(uploads);

                if (imageFile.Length > 0)
                {
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyToAsync(stream);
                    }
                }
            }
            
            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                ParksModel park = new ParksModel
                {
                    parkname = parkName, 
                    parkcity = parkCity, 
                    parkmetro = parkMetro,
                    maintext = mainText,
                    imagespath = imagesPath,
                    smallimage = imagesPath[0],
                    enterinfotext = enterInfoText,
                    typeid = typeId
                };

                applicationContext.parks.Add(park);
                applicationContext.SaveChanges();
            }
        }

        public void NewsAdd(string newsTitle, string newsImagePath, IFormFile[] newsImage, string newsText)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;
            
            foreach (var imageFile in newsImage)
            {
                string uploads = Path.Combine("StaticFiles/images/news");
                Directory.CreateDirectory(uploads);

                if (imageFile.Length > 0)
                {
                    var filePath = Path.Combine(uploads, imageFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyToAsync(stream);
                    }
                }
            }
            
            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                NewsModel news = new NewsModel
                {
                    newstitle = newsTitle,
                    newsimage = newsImagePath,
                    newsdate = DateTime.UtcNow,
                    newstext = newsText
                };

                applicationContext.news.Add(news);
                applicationContext.SaveChanges();
            }
        }
    }
}