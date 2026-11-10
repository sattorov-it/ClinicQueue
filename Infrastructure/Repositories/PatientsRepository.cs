using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PatientRepository(AppDbContext appDbContext) : IPatientsRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddPatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "insert into patients (fullname, phone, birthdate) values (@FullName, @Phone, @BirthDate)";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "update patients set fullname = @FullName, phone = @Phone, birthdate = @BirthDate where id = @Id";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> DeactivatePatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "update patients set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Patient?> GetPatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from patients where id = @id";
        return await connection.QuerySingleOrDefaultAsync<Patient>(query, new { id });
    }

    public async Task<Patient?> GetPatientByPhoneAsync(string phone)
    {
        using var connection = _context.Connection();
        var query = "select * from patients where phone = @phone";
        return await connection.QuerySingleOrDefaultAsync<Patient>(query, new { phone });
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from patients order by id";
        var patients = await connection.QueryAsync<Patient>(query);
        return patients.ToList();
    }
}