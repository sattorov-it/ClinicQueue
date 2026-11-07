using Domain.Models;

namespace Domain.Interfaces;

public interface IDoctorsRepository
{
    Task<bool> AddDoctorAsync(Doctors doctor);
    Task<List<Doctors>> GetDoctorsAsync();
    Task<Doctors> GetDoctorAsync(int id);
    Task<bool> UpdateDoctorAsync(int id);
    Task<bool> DeactivateDoctorAsync(int id);
}