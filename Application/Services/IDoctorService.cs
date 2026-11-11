using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class DoctorService(IDoctorsRepository doctorRepository) : IDoctorService
{
    private IDoctorsRepository repository = doctorRepository;

    public async Task<ApiResponse<bool>> CreateDoctorAsync(CreateDoctorDto dto)
    {
        var doctor = new Doctor()
        {
            FullName = dto.FullName,
            Specialty = dto.Specialty,
            HiredAt = dto.HiredAt
        };
        var res = await repository.AddDoctorAsync(doctor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Created!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not created.", res);
    }

    public async Task<ApiResponse<bool>> UpdateDoctorAsync(UpdateDoctorDto dto)
    {
        var doctor = new Doctor()
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Specialty = dto.Specialty,
            HiredAt = dto.HiredAt
        };
        var res = await repository.UpdateDoctorAsync(doctor);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateDoctorAsync(int id)
    {
        var res = await repository.DeactivateDoctorAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not deactivated.", res);
    }

    public async Task<ApiResponse<GetDoctorDto>> GetDoctorAsync(int id)
    {
        var res = await repository.GetDoctorAsync(id);
        return res != null
        ? new ApiResponse<GetDoctorDto>(HttpStatusCode.OK, "Doctor with given id.", new GetDoctorDto()
        {
            Id = res.Id,
            FullName = res.FullName,
            Specialty = res.Specialty,
            IsActive = res.IsActive,
            HiredAt = res.HiredAt
        })
        : new ApiResponse<GetDoctorDto>(HttpStatusCode.NotFound, "No doctor with given id.");
    }

    public async Task<ApiResponse<List<GetDoctorDto>>> GetDoctorsAsync()
    {
        var doctors = await repository.GetDoctorsAsync();
        var res = doctors.Select(x => new GetDoctorDto()
        {
            Id = x.Id,
            FullName = x.FullName,
            Specialty = x.Specialty,
            IsActive = x.IsActive,
            HiredAt = x.HiredAt
        }).ToList();
        return new ApiResponse<List<GetDoctorDto>>(HttpStatusCode.OK, "List of doctors.", res);
    }

}