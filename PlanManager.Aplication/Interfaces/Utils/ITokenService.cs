using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ITokenService
{
    Task<string> GenerateToken(User user);
    public bool ValidateToken(string token);
}