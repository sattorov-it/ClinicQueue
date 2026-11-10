using Domain.Models;

namespace Domain.Interfaces;

public interface IDoctorsRepository
{
    Task<bool> AddDoctorAsync(Doctor doctor);
    Task<bool> UpdateDoctorAsync(Doctor doctor);
    Task<bool> DeactivateDoctorAsync(int id);
    Task<Doctor?> GetDoctorAsync(int id);
    Task<List<Doctor>> GetDoctorsAsync();
}