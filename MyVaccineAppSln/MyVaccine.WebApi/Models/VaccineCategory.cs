namespace MyVaccine.WebApi.Models;

public class VaccineCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
}
