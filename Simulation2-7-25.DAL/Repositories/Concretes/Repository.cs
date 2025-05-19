using Microsoft.EntityFrameworkCore;
using Simulation2_7_25.DAL.Contexts;
using Simulation2_7_25.DAL.Repositories.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation2_7_25.DAL.Repositories.Concretes;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public Repository(AppDbContext context)
    {
        _context = context;
    }

    private readonly AppDbContext _context;
    public DbSet<TEntity> Table => _context.Set<TEntity>();

    #region Create
    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }
    #endregion

    #region Read
    public IQueryable<TEntity> GetAll(bool isTracking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = !isTracking ? query.AsNoTracking() : query;

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public IQueryable<TEntity> GetByCondition(Func<TEntity, bool> predicate, bool isTracking = false, params string[] includes)
    {
        var query = GetAll(isTracking, includes);

        query = query.Where(predicate).AsQueryable();

        return query;
    }

    public TEntity? GetById(int id, bool isTracking = false, params string[] includes)
    {
        var query = GetAll(isTracking, includes);

        return query.FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
    {
        var query = GetAll(isTracking, includes);

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }
    #endregion

    #region Update
    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }
    #endregion

    #region Delete
    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }
    #endregion

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
