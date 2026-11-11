namespace Application.DTOs;

public class CreatePatientDto
{
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
}