namespace RusParksBack.Interfaces;

public interface IUserManageService
{
    public void UserReg(string email, string login, string password);

    public IResult UserLogin(string login, string password);

    public string RoleGet(int userid);
}