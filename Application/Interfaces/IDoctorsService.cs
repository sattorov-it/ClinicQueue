using Application.Responses;
using Domain.Models;
namespace Domain.Interfaces;

public interface IDoctorsService
{
    Task<ApiResponse<string>> AddDoctorAsync(Doctors doctor);
    Task<ApiResponse<List<Doctors>>> GetDoctorsAsync();
    Task<ApiResponse<Doctors>> GetDoctorAsync(int id);
    Task<ApiResponse<string>> UpdateDoctorAsync(Doctors doctor);
    Task<ApiResponse<string>> DeactivateDoctorAsync(int id);
    Task<ApiResponse<string>> UpdateDoctorAsync(int id, Doctors doctor);

}