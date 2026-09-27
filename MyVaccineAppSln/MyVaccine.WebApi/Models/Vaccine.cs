namespace MyVaccine.WebApi.Models;

public class Vaccine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<VaccineCategory> Categories { get; set; } = new List<VaccineCategory>();
    public bool RequiresBooster { get; set; }
}
