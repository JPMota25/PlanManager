using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class UserRepository : Repository<User>, IUserRepository {
	private readonly PlanManagerDbContext _context;

	public UserRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<User?> GetUser(string username) {
		var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
		return user;
	}
}