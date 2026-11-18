using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository(ApplicationDbContext appDbContext): IPatientsRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddPatientAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeactivatePatientAsync(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==id);
        if (patient != null)
        {
            patient.IsActive=false;
        }
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

    public async Task<Patient> GetPatientAsync(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==id);
        return patient??new(); 
    }

    public async Task<Patient> GetPatientByPhoneAsync(string phone)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x=>x.Phone==phone);
        return patient??new(); 
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        var pat = await _context.Patients.FirstOrDefaultAsync(x=>x.Id==patient.Id);
        if (pat != null)
        {
            pat.FullName=patient.FullName;
            pat.Phone=patient.Phone;
            pat.BirthDate=patient.BirthDate;
        }
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

}