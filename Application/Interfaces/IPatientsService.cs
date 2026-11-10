using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponse<bool>> AddPatientAsync(Patient patient);
    Task<ApiResponse<bool>> UpdatePatientAsync(int id, Patient patient);
    Task<ApiResponse<bool>> DeactivatePatientAsync(int id);
    Task<ApiResponse<Patient>> GetPatientAsync(int id);
    Task<ApiResponse<List<Patient>>> GetPatientsAsync();
}