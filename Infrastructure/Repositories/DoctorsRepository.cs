using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class DoctorRepository(AppDbContext appDbContext) : IDoctorsRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddDoctorAsync(Doctor doctor)
    {
        using var connection = _context.Connection();
        var query = "insert into doctors (fullname, specialty, hiredat) values (@FullName, @Specialty, @HiredAt)";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> UpdateDoctorAsync(Doctor doctor)
    {
        using var connection = _context.Connection();
        var query = "update doctors set fullname = @FullName, specialty = @Specialty, hiredat = @HiredAt where id = @Id";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> DeactivateDoctorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "update doctors set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Doctor?> GetDoctorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from doctors where id = @id";
        return await connection.QuerySingleOrDefaultAsync<Doctor>(query, new { id });
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from doctors order by id";
        var doctors = await connection.QueryAsync<Doctor>(query);
        return doctors.ToList();
    }
}