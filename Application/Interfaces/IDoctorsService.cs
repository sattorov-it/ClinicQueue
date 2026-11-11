using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponse<bool>> CreateDoctorAsync(CreateDoctorDto dto);
    Task<ApiResponse<bool>> UpdateDoctorAsync(UpdateDoctorDto dto);
    Task<ApiResponse<bool>> DeactivateDoctorAsync(int id);
    Task<ApiResponse<GetDoctorDto>> GetDoctorAsync(int id);
    Task<ApiResponse<List<GetDoctorDto>>> GetDoctorsAsync();
}