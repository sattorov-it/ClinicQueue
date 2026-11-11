namespace Application.DTOs;

public class UpdateDoctorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public DateTime HiredAt { get; set; }
}