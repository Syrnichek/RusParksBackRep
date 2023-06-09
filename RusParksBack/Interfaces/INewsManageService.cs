using RusParksBack.Models;

namespace RusParksBack.Interfaces
{
    public interface INewsManageService
    {
        public List<NewsModel> GetNewsAll();

        public List<NewsModel> GetNewsById(int newsid);
    }
}