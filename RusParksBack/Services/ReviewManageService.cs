using Microsoft.EntityFrameworkCore;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services
{
    public class ReviewManageService : IReviewManageService
    {
        public void ReviewAdd(int parkid, int userid, int reviewscore, string reviewtext)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                ReviewsModel review = new ReviewsModel {parkid = parkid, userid = userid, reviewscore = reviewscore, reviewtext = reviewtext};
                applicationContext.reviews.Add(review);
                applicationContext.SaveChanges();
            }
        }

        public List<ReviewsModel> ReviewsGetAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IEnumerable<ReviewsModel> reviewsIEnumerable = applicationContext.reviews;
                return reviewsIEnumerable.ToList();
            }
        }

        public List<ReviewsModel> ReviewsGetByParkId(int parkid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<ReviewsModel> reviewsIEnumerable = applicationContext.reviews;
                var reviews = reviewsIEnumerable.Where(r => r.parkid == parkid);
                return reviews.ToList();
            }
        }

        public double ReviewsGetAverage(int parkid)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
            var options = optionsBuilder.Options;

            using (ApplicationContext applicationContext = new ApplicationContext(options))
            {
                IQueryable<ReviewsModel> reviewsIEnumerable = applicationContext.reviews;
                var averageReview = reviewsIEnumerable.Where(r => r.parkid == parkid).Average(a => a.reviewscore);
                return averageReview;
            }
        }
    }
}