using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class DoctorRepository(AppDbContext appDbContext) : IDoctorsRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddDoctorAsync(Doctors doctor)
    {
        var connection = _context.Connection();
        var query = "insert into doctors (fullname, specialty, hiredat) values (@fullname, @specialty, @hiredat)";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> DeactivateDoctorAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update doctors set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Doctors> GetDoctorAsync(int id)
    {
        var connection = _context.Connection();
        var query = "select * from doctors where id = @id";
        var doctor = await connection.QuerySingleOrDefaultAsync<Doctors>(query, new { id });
        return doctor;
    }

    public async Task<List<Doctors>> GetDoctorsAsync()
    {
        var connection = _context.Connection();
        var query = "select * from doctors";
        var doctors = await connection.QueryAsync<Doctors>(query);
        return doctors.ToList();
    }

    public async Task<bool> UpdateDoctorAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update doctors set fullname = @fullname, specialty = @specialty, hiredat = @hiredat where id = @id";
        var res = await connection.ExecuteAsync(query, query);
        return res > 0;
    }

}