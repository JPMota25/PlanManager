using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ITokenService {
	string GenerateToken(User user);
	public bool ValidateToken(string token);
}