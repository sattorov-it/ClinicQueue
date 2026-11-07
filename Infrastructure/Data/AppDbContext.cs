using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    private string connectionString = "Host=localhost;Port=5432;Database=ClinicQueue API;Username=postgres;Password=1234";

    public IDbConnection Connection() => new NpgsqlConnection(connectionString);

    internal object GetConnection()
    {
        throw new NotImplementedException();
    }
}