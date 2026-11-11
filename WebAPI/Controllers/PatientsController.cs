using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientsController(IPatientService patientService) : ControllerBase
{
    private IPatientService service = patientService;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreatePatient(CreatePatientDto dto)
    {
        return await service.CreatePatientAsync(dto);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetPatientDto>>> GetPatients()
    {
        return await service.GetPatientsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetPatientDto>> GetPatient(int id)
    {
        return await service.GetPatientAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePatient(UpdatePatientDto dto)
    {
        return await service.UpdatePatientAsync(dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivatePatient(int id)
    {
        return await service.DeactivatePatientAsync(id);
    }
}