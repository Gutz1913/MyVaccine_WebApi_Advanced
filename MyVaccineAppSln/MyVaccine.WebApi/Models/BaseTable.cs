namespace MyVaccine.WebApi.Models;

public class BaseTable
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
