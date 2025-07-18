using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ITokenService {
	Task<JwtDto> GenerateToken(LoginCommand model);
	public bool ValidateToken(string token);
}