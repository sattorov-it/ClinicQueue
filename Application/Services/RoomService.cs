using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class RoomService(IRoomsRepository roomRepository) : IRoomService
{
    private IRoomsRepository repository = roomRepository;

    public async Task<ApiResponse<bool>> CreateRoomAsync(CreateRoomDto dto)
    {
        var room = new Room()
        {
            Name = dto.Name
        };
        var res = await repository.AddRoomAsync(room);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Created!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not created.", res);
    }

    public async Task<ApiResponse<bool>> UpdateRoomAsync(UpdateRoomDto dto)
    {
        var room = new Room()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        var res = await repository.UpdateRoomAsync(room);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateRoomAsync(int id)
    {
        var res = await repository.DeactivateRoomAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not deactivated.", res);
    }

    public async Task<ApiResponse<List<GetRoomDto>>> GetRoomsAsync()
    {
        var rooms = await repository.GetRoomsAsync();
        var res = rooms.Select(x => new GetRoomDto()
        {
            Id = x.Id,
            Name = x.Name,
            IsActive = x.Isactive
        }).ToList();
        return new ApiResponse<List<GetRoomDto>>(HttpStatusCode.OK, "List of rooms.", res);
    }
}