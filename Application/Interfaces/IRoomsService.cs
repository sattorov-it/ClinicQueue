using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponse<bool>> CreateRoomAsync(CreateRoomDto dto);
    Task<ApiResponse<bool>> UpdateRoomAsync(UpdateRoomDto dto);
    Task<ApiResponse<bool>> DeactivateRoomAsync(int id);
    Task<ApiResponse<List<GetRoomDto>>> GetRoomsAsync();
}