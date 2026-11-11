using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class PatientService(IPatientsRepository patientRepository) : IPatientService
{
    private IPatientsRepository repository = patientRepository;

    public async Task<ApiResponse<bool>> CreatePatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient()
        {
            FullName = dto.FullName,
            Phone = dto.Phone,
            BirthDate = dto.BirthDate
        };
        var res = await repository.AddPatientAsync(patient);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Created!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not created.", res);
    }

    public async Task<ApiResponse<bool>> UpdatePatientAsync(UpdatePatientDto dto)
    {
        var patient = new Patient()
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Phone = dto.Phone,
            BirthDate = dto.BirthDate
        };
        var res = await repository.UpdatePatientAsync(patient);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivatePatientAsync(int id)
    {
        var res = await repository.DeactivatePatientAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not deactivated.", res);
    }

    public async Task<ApiResponse<GetPatientDto>> GetPatientAsync(int id)
    {
        var res = await repository.GetPatientAsync(id);
        return res != null
        ? new ApiResponse<GetPatientDto>(HttpStatusCode.OK, "Patient with given id.", new GetPatientDto()
        {
            Id = res.Id,
            FullName = res.FullName,
            Phone = res.Phone,
            BirthDate = res.BirthDate,
            IsActive = res.IsActive,
            CreatedAt = res.CreatedAt
        })
        : new ApiResponse<GetPatientDto>(HttpStatusCode.NotFound, "No patient with given id.");
    }

    public async Task<ApiResponse<List<GetPatientDto>>> GetPatientsAsync()
    {
        var patients = await repository.GetPatientsAsync();
        var res = patients.Select(v => new GetPatientDto()
        {
            Id = v.Id,
            FullName = v.FullName,
            Phone = v.Phone,
            BirthDate = v.BirthDate,
            IsActive = v.IsActive,
            CreatedAt = v.CreatedAt
        }).ToList();
        return new ApiResponse<List<GetPatientDto>>(HttpStatusCode.OK, "List of patients.", res);
    }
}