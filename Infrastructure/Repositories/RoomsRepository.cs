using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository(ApplicationDbContext appDbContext): IRoomsRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddRoomAsync(Room room)
    {
        _context.Rooms.Add(room);
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeactivateRoomAsync(int id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x=>x.Id==id);
        if (room != null)
        {
            room.IsActive=false;
        }
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

    public async Task<Room> GetRoomAsync(int id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x=>x.Id==id);
        return room??new(); 
    }

    public async Task<List<Room>> GetRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        var r = await _context.Rooms.FirstOrDefaultAsync(x=>x.Id==room.Id);
        if (r != null)
        {
            r.Name=room.Name;
        }
        var res = await _context.SaveChangesAsync();
        return res>0;
    }

}