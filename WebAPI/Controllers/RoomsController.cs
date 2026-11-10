using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("rooms")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    private  IRoomService _service = roomService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddRoom(Room room)
    {
        return await _service.AddRoomAsync(room);
    }

    [HttpGet]
    public async Task<ApiResponse<List<Room>>> GetRooms()
    {
        return await _service.GetRoomsAsync();
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateRoom(int id, Room room)
    {
        return await _service.UpdateRoomAsync(id, room);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateRoom(int id)
    {
        return await _service.DeactivateRoomAsync(id);
    }
}