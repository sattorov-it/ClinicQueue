namespace Domain.Models;

public class Doctors
{
    public int Id { get; set; }
    public string fullanme { get; set; } = null!;
    public string specialty { get; set; } = null!;
    public DateTime hiredat { get; set; }
}
