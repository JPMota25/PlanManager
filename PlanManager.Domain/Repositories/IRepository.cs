using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Repositories;

public interface IRepository<T> where T : class {
	Task<T?> GetByIdAsync(Id id); // Recuperar por ID
	Task<IList<T>> GetAllAsync(); // Recuperar todos os registros
	Task AddAsync(T entity); // Adicionar um novo
	void Update(T entity); // Atualizar um existente
	Task DeleteAsync(Id id); // Deletar por ID
	void DeleteAll();
	Task SaveChangesAsync();
}