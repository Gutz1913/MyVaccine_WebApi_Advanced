namespace MyVaccine.WebApi.DTOs;

public class UserRegistrationResponseDTO
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public bool IsSuccess { get; set; }
}
