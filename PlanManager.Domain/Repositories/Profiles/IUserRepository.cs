using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Repositories.Profiles;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUser(string username);
    Task<IList<LoginReportDto>> LoginReport(string? email, string? document, DateTime initialTime, DateTime? finalTime, int skip, int take);
    Task<IList<string>> GetUserPermissions(string idUser);
}