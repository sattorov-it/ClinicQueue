using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorsController(IDoctorService doctorService) : ControllerBase
{
    private IDoctorService service = doctorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreateDoctor(CreateDoctorDto dto)
    {
        return await service.CreateDoctorAsync(dto);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetDoctorDto>>> GetDoctors()
    {
        return await service.GetDoctorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetDoctorDto>> GetDoctor(int id)
    {
        return await service.GetDoctorAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDoctor(UpdateDoctorDto dto)
    {
        return await service.UpdateDoctorAsync(dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateDoctor(int id)
    {
        return await service.DeactivateDoctorAsync(id);
    }
}