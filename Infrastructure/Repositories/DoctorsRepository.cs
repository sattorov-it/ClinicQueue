using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DoctorRepository(ApplicationDbContext appDbContext) : IDoctorsRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddDoctorAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeactivateDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        if (doctor != null)
        {
            doctor.IsActive = false;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Doctor> GetDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        return doctor ?? new();
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task<bool> UpdateDoctorAsync(Doctor doctor)
    {
        var doc = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);
        if (doc != null)
        {
            doc.FullName = doctor.FullName;
            doc.Specialty = doctor.Specialty;
            doc.HiredAt = doctor.HiredAt;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

}