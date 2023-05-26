using RusParksBack.Models;

namespace RusParksBack.Interfaces
{
    public interface IReviewManageService
    {
        public void ReviewAdd(int parkid, int Userid, int reviewscore, string reviewtext);

        public List<ReviewsModel> ReviewsGetAll();

        public List<ReviewsModel> ReviewsGetByParkId(int parkid);

        public void ReviewDelete(int reviewid);
    }
}