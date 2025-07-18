using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class UserRepository : Repository<User>, IUserRepository {
	private readonly PlanManagerDbContext _context;

	public UserRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public Task<User?> GetUser(string username) {
		throw new NotImplementedException();
	}
}