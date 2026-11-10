using Application.Responses;
using Domain.Models;
namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponse<bool>> AddRoomAsync(Room room);
    Task<ApiResponse<bool>> UpdateRoomAsync(int id, Room room);
    Task<ApiResponse<bool>> DeactivateRoomAsync(int id);
    Task<ApiResponse<List<Room>>> GetRoomsAsync();
}