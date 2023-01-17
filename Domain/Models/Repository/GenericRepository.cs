using Domain.Helper;
using Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Domain.Models.Repository;

public interface IGenericRepository<TEntity> where TEntity : EntityClass
{
    Task Add(TEntity entity);
    Task<List<TEntity>> GetAll();
    Task<TEntity> GetById(long id);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
}

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityClass

{
    private readonly NeoBankContext context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(NeoBankContext context)
    {
        this.context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity> GetById(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void Dispose()
    {
        context?.Dispose();
    }
}