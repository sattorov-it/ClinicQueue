using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientsController(IPatientService patientService) : ControllerBase
{
    private IPatientService _service = patientService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPatient(Patient patient)
    {
        return await _service.AddPatientAsync(patient);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Patient>>> GetPatients()
    {
        return await _service.GetPatientsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Patient>> GetPatient(int id)
    {
        return await _service.GetPatientAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePatient(int id, Patient patient)
    {
        return await _service.UpdatePatientAsync(id, patient);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivatePatient(int id)
    {
        return await _service.DeactivatePatientAsync(id);
    }
}