using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Services.Utils;

public class TokenService : ITokenService {
	public string GenerateToken(User user) {
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity([
				new Claim(ClaimTypes.NameIdentifier, user.Username),
				new Claim(ClaimTypes.Role, "Admin")
			]),
			Expires = DateTime.UtcNow.AddHours(6),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenGerado = tokenHandler.WriteToken(token);
		return tokenGerado;
	}

	public bool ValidateToken(string token) {
		var tokenHandler = new JwtSecurityTokenHandler();
		try {
			tokenHandler.ValidateToken(token, new TokenValidationParameters {
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtKey)),
				ValidateIssuer = false,
				ValidateAudience = false
			}, out _);
			return true;
		}
		catch {
			return false;
		}
	}
}