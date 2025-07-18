using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Aplication.Services.Utils;

public class TokenService : ITokenService {
	private readonly PlanManagerDbContext _context;
	private readonly IUserService _userService;
	private readonly ILogActivityService _logActivityService;

	public TokenService(PlanManagerDbContext context, IUserService userService, ILogActivityService logActivityService) {
		_context = context;
		_userService = userService;
		_logActivityService = logActivityService;
	}

	public async Task<JwtDto> GenerateToken(LoginCommand model) {
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

		var tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new ClaimsIdentity([
				// Adicionar claims
			]),
			Expires = DateTime.UtcNow.AddHours(6),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenGerado = tokenHandler.WriteToken(token);
		// await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.Login, userDb.Id, "User logged successfully.");
		return new JwtDto(tokenGerado);
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