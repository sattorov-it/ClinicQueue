namespace Application.DTOs;

public class GetPatientDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}