using Microsoft.AspNetCore.Identity;
using PlanManager.Aplication.Interfaces;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Services.Utils;

public class PasswordHashService : IPasswordHashService {
	public bool VerifyPassword(string password, string hash, User user) {
		var hasher = new PasswordHasher<object>();
		return hasher.VerifyHashedPassword(user, password, hash) == PasswordVerificationResult.Success;
	}

	public string HashPassword(string password) {
		var hasher = new PasswordHasher<User>();
		var result = hasher.HashPassword(null!, password);
		return result;
	}
}