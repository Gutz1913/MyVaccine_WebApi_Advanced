namespace MyVaccine.WebApi.Models;

public class Allergy
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
