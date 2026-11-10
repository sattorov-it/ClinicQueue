using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class RoomService(IRoomsRepository roomRepository) : IRoomService
{
    private IRoomsRepository repository = roomRepository;

    public async Task<ApiResponse<bool>> AddRoomAsync(Room room)
    {
        var res = await repository.AddRoomAsync(room);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateRoomAsync(int id, Room room)
    {
        var res = await repository.UpdateRoomAsync(room);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateRoomAsync(int id)
    {
        var res = await repository.DeactivateRoomAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<ApiResponse<List<Room>>> GetRoomsAsync()
    {
        var res = await repository.GetRoomsAsync();
        return new ApiResponse<List<Room>>(HttpStatusCode.OK, "List of rooms.", res);
    }
}