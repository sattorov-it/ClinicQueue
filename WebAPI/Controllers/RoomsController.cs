using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("rooms")]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    private IRoomService service = roomService;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreateRoom(CreateRoomDto dto)
    {
        return await service.CreateRoomAsync(dto);
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetRoomDto>>> GetRooms()
    {
        return await service.GetRoomsAsync();
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateRoom(UpdateRoomDto dto)
    {
        return await service.UpdateRoomAsync(dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateRoom(int id)
    {
        return await service.DeactivateRoomAsync(id);
    }
}