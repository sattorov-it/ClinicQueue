using Domain.Models;

namespace Domain.Interfaces;

public interface IRoomsRepository
{
    Task<bool> AddRoomAsync(Rooms room);
    Task<List<Rooms>> GetAll();
    Task<Rooms> GetRoomsAsync(int id);
    Task<bool> UpdateRoomAsync(int id);
    Task<bool> DeactivateRoomAsync(int id);
}
