using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class DoctorService(IDoctorsRepository doctorRepository) : IDoctorService
{
    private IDoctorsRepository repository = doctorRepository;

    public async Task<ApiResponse<bool>> AddDoctorAsync(Doctor doctor)
    {
        var res = await repository.AddDoctorAsync(doctor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateDoctorAsync(int id, Doctor doctor)
    {
        var res = await repository.UpdateDoctorAsync(doctor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateDoctorAsync(int id)
    {
        var res = await repository.DeactivateDoctorAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<ApiResponse<Doctor>> GetDoctorAsync(int id)
    {
        var res = await repository.GetDoctorAsync(id);
        return new ApiResponse<Doctor>(HttpStatusCode.OK, "Doctor with given id.", res!);
    }

    public async Task<ApiResponse<List<Doctor>>> GetDoctorsAsync()
    {
        var res = await repository.GetDoctorsAsync();
        return new ApiResponse<List<Doctor>>(HttpStatusCode.OK, "List of doctors.", res);
    }
}