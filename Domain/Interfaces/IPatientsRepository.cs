using Domain.Models;

namespace Domain.Interfaces;

public interface IPatientsRepository
{
    Task<bool> AddPatientAsync(Patient patient);
    Task<bool> UpdatePatientAsync(Patient patient);
    Task<bool> DeactivatePatientAsync(int id);
    Task<Patient?> GetPatientAsync(int id);
    Task<Patient?> GetPatientByPhoneAsync(string phone);
    Task<List<Patient>> GetPatientsAsync();
}