using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            UsersModel user = new UsersModel {email = Email, login = Login, password = Password};
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }

    public IResult UserLogin(string Login, string Password)
    {
        AuthOptions authOptions = new AuthOptions();
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UsersModel? user = applicationContext.users.FirstOrDefault(u => u.login == Login && u.password == Password);
            
            if (user is null) return Results.Unauthorized();

            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.Name, user.login));
            claims.Add(new Claim(ClaimTypes.Role, user.role));
            
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.login
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