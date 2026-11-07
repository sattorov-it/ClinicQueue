using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientsController(IPatientsService patientsService) : ControllerBase
{
    private IPatientsService service = patientsService;

    [HttpPost]
    public async Task<ApiResponse<string>> AddPatient(Patients patient)
    {
        return await service.AddPatientAsync(patient);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Patients>>> GetPatients()
    {
        return await service.GetPatientsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Patients>> GetPatient(int id)
    {
        return await service.GetPatientAsync(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<string>> UpdatePatient(int id, Patients patient)
    {
        return await service.UpdatePatientAsync(id, patient);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<string>> DeactivatePatient(int id)
    {
        return await service.DeactivatePatientAsync(id);
    }
}