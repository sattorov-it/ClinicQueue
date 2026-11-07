using Application.Responses;
using Domain.Models;


namespace Domain.Interfaces;

public interface IRoomsService
{
    Task<ApiResponse<string>> AddRoomAsync(Rooms room);
    Task<ApiResponse<List<Rooms>>> GetRoomsAsync();
    Task<ApiResponse<string>> UpdateRoomAsync(Rooms room);
    Task<ApiResponse<string>> DeactivateRoomAsync(int id);
}