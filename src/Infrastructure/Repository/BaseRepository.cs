using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }
        return entity;
    }

    public async Task CreateAsync(TEntity obj)
    {
        await _dbContext.Set<TEntity>().AddAsync(obj);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Update(obj);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);

        if (entity != null)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
