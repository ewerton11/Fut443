namespace Domain.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity obj);
    Task UpdateAsync(TEntity obj);
    Task DeleteAsync(Guid id);
}
