namespace PlanManager.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id); // Recuperar por ID
    Task<IList<T>> GetAllAsync(); // Recuperar todos os registros
    Task AddAsync(T entity); // Adicionar um novo
    void Update(T entity); // Atualizar um existente
    Task DeleteAsync(string id); // Deletar por ID
    void DeleteAll();
    Task SaveChangesAsync();
}