namespace Application.DTOs;

public class GetRoomDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
}