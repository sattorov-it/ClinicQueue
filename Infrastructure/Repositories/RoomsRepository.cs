using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext appDbContext) : IRoomsRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddRoomAsync(Room room)
    {
        using var connection = _context.Connection();
        var query = "insert into rooms (name) values (@Name)";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        using var connection = _context.Connection();
        var query = "update rooms set name = @Name where id = @Id";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }

    public async Task<bool> DeactivateRoomAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "update rooms set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Room?> GetRoomAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from rooms where id = @id";
        return await connection.QuerySingleOrDefaultAsync<Room>(query, new { id });
    }

    public async Task<List<Room>> GetRoomsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from rooms order by id";
        var rooms = await connection.QueryAsync<Room>(query);
        return rooms.ToList();
    }
}