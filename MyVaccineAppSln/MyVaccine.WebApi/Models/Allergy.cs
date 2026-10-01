namespace MyVaccine.WebApi.Models;

public class Allergy : BaseTable
{
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
