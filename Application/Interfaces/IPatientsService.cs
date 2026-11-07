using Application.Responses;
using Domain.Models;
namespace Domain.Interfaces;

public interface IPatientsService
{
    Task<ApiResponse<string>> AddPatientAsync(Patients patient);
    Task<ApiResponse<List<Patients>>> GetPatientsAsync();
    Task<ApiResponse<Patients>> GetPatientAsync(int id);
    Task<ApiResponse<string>> UpdatePatientAsync(Patients patient);
    Task<ApiResponse<string>> DeactivatePatientAsync(int id);
    Task<ApiResponse<string>> UpdatePatientAsync(int id, Patients patient);

}