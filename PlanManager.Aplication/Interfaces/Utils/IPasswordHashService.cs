using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface IPasswordHashService {
	bool VerifyPassword(string password, string hash, User user);
	string HashPassword(string password);
}