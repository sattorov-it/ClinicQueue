using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class PatientService(IPatientsRepository patientRepository) : IPatientService
{
    private IPatientsRepository repository = patientRepository;

    public async Task<ApiResponse<bool>> AddPatientAsync(Patient patient)
    {
        var res = await repository.AddPatientAsync(patient);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdatePatientAsync(int id, Patient patient)
    {
        var res = await repository.UpdatePatientAsync(patient);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivatePatientAsync(int id)
    {
        var res = await repository.DeactivatePatientAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<ApiResponse<Patient>> GetPatientAsync(int id)
    {
        var res = await repository.GetPatientAsync(id);
        return new ApiResponse<Patient>(HttpStatusCode.OK, "Patient with given id.", res!);
    }

    public async Task<ApiResponse<List<Patient>>> GetPatientsAsync()
    {
        var res = await repository.GetPatientsAsync();
        return new ApiResponse<List<Patient>>(HttpStatusCode.OK, "List of patients.", res);
    }

}