using RusParksBack.Models;

namespace RusParksBack.Interfaces;

public interface IParkManageService
{
    public List<ParksModel> GetParksAll();

    public List<ParksModel> GetParksById(int parkid);

    public List<LandmarksModel> GetLandmarksByPark(int parkid);
}