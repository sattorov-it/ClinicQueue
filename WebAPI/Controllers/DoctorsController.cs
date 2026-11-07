using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorsController(IDoctorsService doctorsService) : ControllerBase
{
    private IDoctorsService service = doctorsService;

    [HttpPost]
    public async Task<ApiResponse<string>> AddDoctor(Doctors doctor)
    {
        return await service.AddDoctorAsync(doctor);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Doctors>>> GetDoctors()
    {
        return await service.GetDoctorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Doctors>> GetDoctor(int id)
    {
        return await service.GetDoctorAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<string>> UpdateDoctor(int id, Doctors doctor)
    {
        return await service.UpdateDoctorAsync(id, doctor);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<string>> DeactivateDoctor(int id)
    {
        return await service.DeactivateDoctorAsync(id);
    }
}