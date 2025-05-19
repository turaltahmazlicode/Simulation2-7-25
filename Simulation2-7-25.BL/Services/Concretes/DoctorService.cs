using Microsoft.EntityFrameworkCore;
using Simulation2_7_25.DAL.Models;
using Simulation2_7_25.DAL.Repositories.Abstactions;

namespace Simulation2_7_25.BL.Services.Concretes;
public class DoctorService
{
    public DoctorService(IRepository<Doctor> repository)
    {
        _repository = repository;
    }
    private readonly IRepository<Doctor> _repository;

    #region Create
    public async Task AddAsync(Doctor doctor)
    {
        await _repository.AddAsync(doctor);
    }
    #endregion

    #region Read
    public List<Doctor> GetAll(bool isTracking = false, params string[] includes)
    {
        return _repository.GetAll(isTracking, includes).ToList();
    }

    public async Task<List<Doctor>> GetAllAsync(bool isTracking = false, params string[] includes)
    {
        return await _repository.GetAll(isTracking, includes).ToListAsync();
    }

    public List<Doctor> GetByCondition(Func<Doctor, bool> predicate, bool isTracking = false, params string[] includes)
    {
        return _repository.GetByCondition(predicate, isTracking, includes).ToList();
    }

    public async Task<List<Doctor>> GetByConditionAsync(Func<Doctor, bool> predicate, bool isTracking = false, params string[] includes)
    {
        return await _repository.GetByCondition(predicate, isTracking, includes).ToListAsync();
    }

    public Doctor? GetById(int id, bool isTracking = false, params string[] includes)
    {
        return _repository.GetById(id, isTracking, includes);
    }

    public async Task<Doctor?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
    {
        return await _repository.GetByIdAsync(id, isTracking, includes);
    }

    public Doctor? GetIfExist(int id, bool isTracking = false, params string[] includes)
    {
        return GetById(id, isTracking, includes) ?? throw new Exception("Proffesstion is not exist");
    }

    public Doctor? GetIfExist(Doctor doctor, bool isTracking = false, params string[] includes)
    {
        return GetIfExist(doctor.Id, isTracking, includes);
    }

    public async Task<Doctor?> GetIfExistAsync(int id, bool isTracking = false, params string[] includes)
    {
        return await GetByIdAsync(id, isTracking, includes) ?? throw new Exception("Proffesstion is not exist");
    }

    public async Task<Doctor?> GetIfExistAsync(Doctor doctor, bool isTracking = false, params string[] includes)
    {
        return await GetIfExistAsync(doctor.Id, isTracking, includes);
    }
    #endregion

    #region Update
    public void Update(Doctor doctor)
    {
        GetIfExist(doctor.Id);
        _repository.Update(doctor);
    }
    #endregion

    #region Delete
    public void Delete(Doctor doctor)
    {
        _repository.Delete(GetIfExist(doctor.Id));
    }
    #endregion

    public async Task<int> SaveChangesAsync()
    {
        return await _repository.SaveChangesAsync();
    }
}
