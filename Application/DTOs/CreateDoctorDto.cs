namespace Application.DTOs;

public class CreateDoctorDto
{
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public DateTime HiredAt { get; set; }
}