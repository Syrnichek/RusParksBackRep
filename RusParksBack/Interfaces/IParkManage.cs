using RusParksBack.Models;

namespace RusParksBack.Interfaces;

public interface IParkManage
{
    public ParksModel GetParksAll();

    public ParksModel GetParksByType(int type);
}