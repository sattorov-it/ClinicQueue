namespace Domain.Models;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
