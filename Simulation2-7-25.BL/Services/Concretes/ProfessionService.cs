using Microsoft.EntityFrameworkCore;
using Simulation2_7_25.DAL.Models;
using Simulation2_7_25.DAL.Repositories.Abstactions;

namespace Simulation2_7_25.BL.Services.Concretes;
public class ProfessionService
{
    public ProfessionService(IRepository<Profession> repository)
    {
        _repository = repository;
    }
    private readonly IRepository<Profession> _repository;

    #region Create
    public async Task AddAsync(Profession profession)
    {
        await _repository.AddAsync(profession);
    }
    #endregion

    #region Read
    public List<Profession> GetAll(bool isTracking = false, params string[] includes)
    {
        return _repository.GetAll(isTracking, includes).ToList();
    }

    public async Task<List<Profession>> GetAllAsync(bool isTracking = false, params string[] includes)
    {
        return await _repository.GetAll(isTracking, includes).ToListAsync();
    }

    public List<Profession> GetByCondition(Func<Profession, bool> predicate, bool isTracking = false, params string[] includes)
    {
        return _repository.GetByCondition(predicate, isTracking, includes).ToList();
    }

    public async Task<List<Profession>> GetByConditionAsync(Func<Profession, bool> predicate, bool isTracking = false, params string[] includes)
    {
        return await _repository.GetByCondition(predicate, isTracking, includes).ToListAsync();
    }

    public Profession? GetById(int id, bool isTracking = false, params string[] includes)
    {
        return _repository.GetById(id, isTracking, includes);
    }

    public async Task<Profession?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
    {
        return await _repository.GetByIdAsync(id, isTracking, includes);
    }

    public Profession? GetIfExist(int id, bool isTracking = false, params string[] includes)
    {
        return GetById(id, isTracking, includes) ?? throw new Exception("Proffesstion is not exist");
    }

    public Profession? GetIfExist(Profession profession, bool isTracking = false, params string[] includes)
    {
        return GetIfExist(profession.Id, isTracking, includes);
    }

    public async Task<Profession?> GetIfExistAsync(int id, bool isTracking = false, params string[] includes)
    {
        return await GetByIdAsync(id, isTracking, includes) ?? throw new Exception("Proffesstion is not exist");
    }

    public async Task<Profession?> GetIfExistAsync(Profession profession, bool isTracking = false, params string[] includes)
    {
        return await GetIfExistAsync(profession.Id, isTracking, includes);
    }
    #endregion

    #region Update
    public void Update(Profession profession)
    {
        GetIfExist(profession.Id);
        _repository.Update(profession);
    }
    #endregion

    #region Delete
    public void Delete(Profession profession)
    {
        _repository.Delete(GetIfExist(profession.Id));
    }
    #endregion

    public async Task<int> SaveChangesAsync()
    {
        return await _repository.SaveChangesAsync();
    }
}
