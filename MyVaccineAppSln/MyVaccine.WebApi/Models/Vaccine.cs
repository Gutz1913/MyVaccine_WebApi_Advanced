namespace MyVaccine.WebApi.Models;

public class Vaccine : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public bool RequiresBooster { get; set; }
    public List<VaccineCategory> Categories { get; set; } = new List<VaccineCategory>();
}

