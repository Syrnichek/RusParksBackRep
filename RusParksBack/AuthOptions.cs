using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RusParksBack;

public class AuthOptions
{
    public const string ISSUER = "AuthServer"; // издатель токена
    public const string AUDIENCE = "AuthClient"; // потребитель токена
    const string KEY = "supersecret_secretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}