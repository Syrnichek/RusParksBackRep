using RusParksBack.Models;

namespace RusParksBack.Interfaces
{
    public interface IReviewManageService
    {
        public void ReviewAdd(int parkid, int Userid, int reviewscore, string reviewtext, string userlogin);

        public List<ReviewsModel> ReviewsGetAll();

        public List<ReviewsModel> ReviewsGetByParkId(int parkid);

        public double ReviewsGetAverage(int parkid);
    }
}