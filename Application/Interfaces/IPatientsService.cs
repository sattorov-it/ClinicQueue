using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponse<bool>> CreatePatientAsync(CreatePatientDto dto);
    Task<ApiResponse<bool>> UpdatePatientAsync(UpdatePatientDto dto);
    Task<ApiResponse<bool>> DeactivatePatientAsync(int id);
    Task<ApiResponse<GetPatientDto>> GetPatientAsync(int id);
    Task<ApiResponse<List<GetPatientDto>>> GetPatientsAsync();
}