using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Infrastructure.DataAccess;

public class RepositoryBase<TEntity,TValue> : IRepository<TEntity,TValue> where TEntity : EntityBase<TValue>, IAggregateRoot
{
    private readonly AppDbContext _dbContext;

    public RepositoryBase(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<TEntity?> FindById<TId>(TId id, CancellationToken cancellationToken = new CancellationToken()) where TId : notnull
    {
        return _dbContext.Set<TEntity>().FirstOrDefaultAsync(x=>x.Id.Equals(id),cancellationToken);
    }

    public Task<TEntity?> FindOne<TId>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new CancellationToken()) where TId : notnull
    {
        return _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression,cancellationToken);
    }

    public Task<List<TEntity>> Find(CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<int> CountAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().CountAsync(cancellationToken: cancellationToken);
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().CountAsync(expression,cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public Task<bool> AnyAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().AnyAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new CancellationToken())
    {
        return _dbContext.Set<TEntity>().AnyAsync(expression,cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = new CancellationToken())
    {
        return (await _dbContext.Set<TEntity>().AddAsync(entity,cancellationToken: cancellationToken)).Entity;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = new CancellationToken())
    {
        var addRangeAsync = entities.ToList();
        
        await _dbContext.Set<TEntity>().AddRangeAsync(addRangeAsync, cancellationToken);

        return addRangeAsync;
    }
    /// <inheritdoc/>
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    /// <inheritdoc/>
    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc/>
    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }
    /// <inheritdoc/>
    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}