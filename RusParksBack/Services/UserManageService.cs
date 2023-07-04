using Microsoft.EntityFrameworkCore;
using RusParksBack.Exceptions;
using RusParksBack.Interfaces;
using RusParksBack.Models;

namespace RusParksBack.Services;

public class UserManageService :IUserManageService
{
    public void UserReg(string Email, string Login, string Password)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            if (applicationContext.users.FirstOrDefault(u => u.email == Email && u.login == Login) != null)
            {
                throw new UserAlreadyExistsException("User already exists");
            }

            UsersModel user = new UsersModel {email = Email, login = Login, password = Password, role = "User"};
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }

    public IResult UserLogin(string Login, string Password)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UsersModel? user = applicationContext.users.FirstOrDefault(u => u.login == Login && u.password == Password);
            
            if (user is null) return Results.Unauthorized();

            var response = new
            {
                userId = user.userid,
                userLogin = user.login
            };
            
            return Results.Json(response);
        }
    }

    public string RoleGet(int userId)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = applicationContext.users.FirstOrDefault(u => u.userid == userId);

            if (user == null)
            {
                throw new UserAlreadyExistsException("User not exists");
            }

            return user.role;
        }
    }
}