namespace RusParksBack.Interfaces;

public interface IUserManage
{
    public void UserReg(string email, string login, string password);

    public IResult UserLogin(string login, string password);
}