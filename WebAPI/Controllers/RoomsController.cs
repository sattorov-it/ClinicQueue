using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("rooms")]
public class RoomsController(IRoomService roomService, ILogger<RoomsController> logger) : ControllerBase
{
    private IRoomService service = roomService;
    private ILogger<RoomsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> CreateRoom(CreateRoomDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.CreateRoomAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpGet]
    public async Task<ApiResponse<List<GetRoomDto>>> GetRooms()
    {
        _logger.LogInformation("Request received.");
        var res = await service.GetRoomsAsync();
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateRoom(UpdateRoomDto dto)
    {
        _logger.LogInformation("Request received.");
        var res = await service.UpdateRoomAsync(dto);
        _logger.LogInformation("Response sent.");
        return res;
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateRoom(int id)
    {
        _logger.LogInformation("Request received.");
        var res = await service.DeactivateRoomAsync(id);
        _logger.LogInformation("Response sent.");
        return res;
    }
}