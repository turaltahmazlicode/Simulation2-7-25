namespace Simulation2_7_25.DAL.Repositories.Abstactions;
public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public DbSet<TEntity> Table { get; }

    #region Create
    public Task AddAsync(TEntity entity);
    #endregion

    #region Read
    public IQueryable<TEntity> GetAll(bool isTracking = false, params string[] includes);

    public IQueryable<TEntity> GetByCondition(Func<TEntity, bool> predicate, bool isTracking = false, params string[] includes);
  
    public TEntity? GetById(int id, bool isTracking = false, params string[] includes);

    public Task<TEntity?> GetByIdAsync(int id, bool isTracking = false, params string[] includes);
    #endregion

    #region Update
    public void Update(TEntity entity);
    #endregion

    #region Delete
    public void Delete(TEntity entity);
    #endregion

    public Task<int> SaveChangesAsync();
}
