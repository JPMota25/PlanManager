using PlanManager.Domain.Repositories;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork {
	private readonly PlanManagerDbContext _context;
	private readonly Dictionary<Type, object> _repositories = new();

	public UnitOfWork(PlanManagerDbContext context) {
		_context = context;
	}

	public IRepository<T> Repository<T>() where T : class {
		var type = typeof(T);
		if (!_repositories.ContainsKey(type))
			_repositories[type] = new Repository<T>(_context);

		return (IRepository<T>)_repositories[type];
	}

	public async Task<int> CommitAsync() {
		return await _context.SaveChangesAsync();
	}

	public void Dispose() {
		_context.Dispose();
	}
}