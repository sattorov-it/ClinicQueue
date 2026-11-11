namespace Application.DTOs;

public class GetDoctorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime HiredAt { get; set; }
}