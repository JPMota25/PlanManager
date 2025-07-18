using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Repositories.Profiles;

public interface IUserRepository : IRepository<User> {
	Task<User?> GetUser(string username);
}