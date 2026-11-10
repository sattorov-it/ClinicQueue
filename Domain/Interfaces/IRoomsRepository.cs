using Domain.Models;

namespace Domain.Interfaces;

public interface IRoomsRepository
{
    Task<bool> AddRoomAsync(Room room);
    Task<bool> UpdateRoomAsync(Room room);
    Task<bool> DeactivateRoomAsync(int id);
    Task<Room?> GetRoomAsync(int id);
    Task<List<Room>> GetRoomsAsync();
}
