using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PatientRepository(AppDbContext appDbContext) : IPatientsRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddPatientAsync(Patients patient)
    {
        var connection = _context.Connection();
        var query = "insert into patients (fullname, phone, birthdate) values (@fullname, @phone, @birthdate)";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> DeactivatePatientAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update patients set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }
    public async Task<Patients> GetPatientAsync(int id)
    {
        var connection = _context.Connection();
        var query = "select * from patients where id = @id";
        var patient = await connection.QuerySingleOrDefaultAsync<Patients>(query, new { id });
        return patient;
    }

    public async Task<List<Patients>> GetPatientsAsync()
    {
        var connection = _context.Connection();
        var query = "select * from patients";
        var patients = await connection.QueryAsync<Patients>(query);
        return patients.ToList();
    }
    public async Task<bool> IsPhoneExistsAsync(string phone)
    {
        var connection = _context.Connection();
        var query = "select count(*) from patients where phone = @phone and id <> @id";
        var amount = await connection.ExecuteScalarAsync<int>(query, new { phone, query });
        return amount > 0;
    }

    public async Task<bool> UpdatePatientAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate where id = @id";
        var res = await connection.ExecuteAsync(query, id);
        return res > 0;
    }
}