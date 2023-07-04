using Microsoft.AspNetCore.Mvc;
using RusParksBack.Exceptions;
using RusParksBack.Interfaces;

namespace RusParksBack.Controllers;

public class UserManageController :Controller
{
    private readonly IUserManageService _userManageService;
    
    public UserManageController(IUserManageService userManageService)
    {
        _userManageService = userManageService;
    }
    
    [HttpGet]
    [Route("api/userManage/UserLogin")]
    public IResult UserLogin(string login, string password)
    {
        return _userManageService.UserLogin(login, password);
    }
    
    [HttpGet]
    [Route("api/userManage/UserReg")]
    public IActionResult UserReg(string email, string login, string password)
    {
        try
        {
            _userManageService.UserReg(email, login, password);
            return Ok();
        }
        catch (UserAlreadyExistsException ex)
        {
            return StatusCode(425, "Пользователь уже существует");
        }
        catch (Exception ex)
        {
            return StatusCode(400, "Введите корректное значение");
        }
    }
    
    [HttpGet]
    [Route("api/userManage/RoleGet")]
    public IActionResult RoleGet(int userId)
    {
        try
        {
            return Ok(_userManageService.RoleGet(userId));
        }
        catch (Exception ex)
        {
            return StatusCode(426, "Ошибка при получении роли");
        }
    }
}