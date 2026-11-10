using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponse<bool>> AddDoctorAsync(Doctor doctor);
    Task<ApiResponse<bool>> UpdateDoctorAsync(int id, Doctor doctor);
    Task<ApiResponse<bool>> DeactivateDoctorAsync(int id);
    Task<ApiResponse<Doctor>> GetDoctorAsync(int id);
    Task<ApiResponse<List<Doctor>>> GetDoctorsAsync();
}