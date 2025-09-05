using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.Enums;
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

	public async Task<IList<LoginReportDto>> LoginReport(string? email, string? document, DateTime initialTime, DateTime? finalTime, int skip, int take) {
		var context = _context.Users.Include(x => x.Person).AsQueryable();
		if (!string.IsNullOrEmpty(email))
			context = context.Where(x => x.Person!.Email == email);
		if (!string.IsNullOrEmpty(document))
			context = context.Where(x => x.Person!.Document == document);
		return await context.Join(_context.LogActivities, user => user.Id, activity => activity.ObjectId, (user, activity) => new { user, activity }).Where(x =>
			x.activity.CreatedAt >= initialTime && (!finalTime.HasValue || x.activity.CreatedAt <= finalTime) && x.activity.Code == ELogCode.Login).Select(x =>
			new LoginReportDto {
				Username = x.user.Username,
				Name = x.user.Person!.FirstName + x.user.Person.LastName,
				LoggedAt = x.activity.CreatedAt
			}).Skip(skip).Take(take).ToListAsync();
	}

    public async Task<IList<string>> GetUserPermissions(string idUser)
    {
        throw new NotImplementedException();
    }
}