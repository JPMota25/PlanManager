using Microsoft.IdentityModel.Tokens;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanManager.Aplication.Services.Utils;

public class TokenService : ITokenService
{
    private readonly IUserService _userService;

    public TokenService(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        byte[] key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        IList<string> permissions = await _userService.PermissionsInUser(user.Id);
        var claims = new List<Claim>();

        claims.Add(new Claim("UserId", user.Id));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Username));

        foreach (string permission in permissions)
        {
            claims.Add(new Claim("action", permission));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenGerado = tokenHandler.WriteToken(token);
        return tokenGerado;
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }
}