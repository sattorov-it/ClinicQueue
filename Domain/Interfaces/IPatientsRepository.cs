using Domain.Models;

namespace Domain.Interfaces;

public interface IPatientsRepository
{
    Task<bool> AddPatientAsync(Patients patient);
    Task<List<Patients>> GetPatientsAsync();
    Task<Patients> GetPatientAsync(int id);
    Task<bool> IsPhoneExistsAsync(string phone);
    Task<bool> UpdatePatientAsync(int id);
    Task<bool> DeactivatePatientAsync(int id);
}