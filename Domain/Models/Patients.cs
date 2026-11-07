namespace Domain.Models;

public class Patients
{
    public int Id { get; set; }
    public string fullname { get; set; } = null!;
    public string phone { get; set; } = null!;
    public DateTime birthdate { get; set; }
    public bool isactive { get; set; }
    public DateTime createdat { get; set; }
}
