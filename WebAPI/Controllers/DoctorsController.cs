using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorsController(IDoctorService doctorService, ILogger<DoctorsController> logger) : ControllerBase
{
    private IDoctorService service = doctorService;
    private ILogger<DoctorsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreateDoctor(CreateDoctorDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.CreateDoctorAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetDoctorDto>>> GetDoctors()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetDoctorsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetDoctorDto>> GetDoctor(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetDoctorAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDoctor(UpdateDoctorDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.UpdateDoctorAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateDoctor(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.DeactivateDoctorAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }
}