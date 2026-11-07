using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext appDbContext) : IRoomsRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddRoomAsync(Rooms room)
    {
        var connection = _context.Connection();
        var query = "insert into rooms (name) values (@name)";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }

    public async Task<bool> DeactivateRoomAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update rooms set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<bool> UpdateRoomAsync(Rooms room)
    {
        var connection = _context.Connection();
        var query = "update rooms set name = @name where id = @id";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }
    public async Task<List<Rooms>> GetAll()
    {
        var connection = _context.Connection();
        var query = "select * from rooms";
        var rooms = await connection.QueryAsync<Rooms>(query);
        return rooms.ToList();
    }

    public async Task<Rooms> GetRoomsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateRoomAsync(int id)
    {
        var connection = _context.Connection();
        var query = "update rooms set name = @name where id = @id";
        var res = await connection.ExecuteAsync(query, id);
        return res > 0;
    }
}