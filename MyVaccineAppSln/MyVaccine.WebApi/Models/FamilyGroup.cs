namespace MyVaccine.WebApi.Models;

public class FamilyGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<User> Users { get; set; } = new List<User>();
}
