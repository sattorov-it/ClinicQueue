using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientsController(IPatientService patientService, ILogger<PatientsController> logger) : ControllerBase
{
    private IPatientService service = patientService;
    private ILogger<PatientsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreatePatient(CreatePatientDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.CreatePatientAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetPatientDto>>> GetPatients()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetPatientsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetPatientDto>> GetPatient(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetPatientAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePatient(UpdatePatientDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.UpdatePatientAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivatePatient(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.DeactivatePatientAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }
}