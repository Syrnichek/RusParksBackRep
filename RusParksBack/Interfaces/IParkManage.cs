using RusParksBack.Models;

namespace RusParksBack.Interfaces;

public interface IParkManage
{
    public List<ParksModel> GetParksAll();

    public List<ParksModel> GetParksByType(int type);

    public IQueryable<ParksModel> GetParksById(int parkid);
}