namespace MyVaccine.WebApi.Models;

public class Dependent
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<VaccineRecord> VaccineRecords { get; set; } = new List<VaccineRecord>();
}
