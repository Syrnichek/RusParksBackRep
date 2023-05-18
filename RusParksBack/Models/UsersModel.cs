using System.ComponentModel.DataAnnotations;

namespace RusParksBack.Models;

public class UsersModel
{
    [Key]
    public int userid { get; set; }
    
    public string login { get; set; }
    
    public string email { get; set; }
    
    public string password { get; set; }

    public int roleid { get; set; }
}