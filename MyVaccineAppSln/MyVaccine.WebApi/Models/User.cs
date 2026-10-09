namespace MyVaccine.WebApi.Models;

public class User : BaseModel
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    public List<FamilyGroup> FamilyGroups { get; set; } = new List<FamilyGroup>();
    public List<VaccineRecord> VaccineRecords { get; set; } = new List<VaccineRecord>();
    public List<Allergy> Allergies { get; set; } = new List<Allergy>();
}
