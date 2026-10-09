namespace MyVaccine.WebApi.Models;

public class VaccineCategory : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
}
