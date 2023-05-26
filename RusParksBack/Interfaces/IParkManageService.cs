using RusParksBack.Models;

namespace RusParksBack.Interfaces;

public interface IParkManageService
{
    public List<ParksModel> GetParksAll();

    public List<ParksModel> GetParksByType(int type);

    public List<ParksModel> GetParksById(int parkid);

    public List<LandmarksModel> GetLandmarksByPark(int parkid);
}