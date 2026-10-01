namespace MyVaccine.WebApi.Models;

public class User : BaseTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AspNetUserId { get; set; } = string.Empty;
    public ApplicationUser AspNetUser { get; set; } = null!;
    public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    public List<FamilyGroup> FamilyGroups { get; set; } = new List<FamilyGroup>();
    public List<VaccineRecord> VaccineRecords { get; set; } = new List<VaccineRecord>();
    public List<Allergy> Allergies { get; set; } = new List<Allergy>();
}
