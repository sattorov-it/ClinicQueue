using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorsController(IDoctorService doctorService) : ControllerBase
{
    private  IDoctorService _service = doctorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(Doctor doctor)
    {
        return await _service.AddDoctorAsync(doctor);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Doctor>>> GetDoctors()
    {
        return await _service.GetDoctorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Doctor>> GetDoctor(int id)
    {
        return await _service.GetDoctorAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDoctor(int id, Doctor doctor)
    {
        return await _service.UpdateDoctorAsync(id, doctor);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateDoctor(int id)
    {
        return await _service.DeactivateDoctorAsync(id);
    }
}