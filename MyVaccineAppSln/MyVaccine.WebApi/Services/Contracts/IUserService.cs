using MyVaccine.WebApi.DTOs;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDTO> AddUserAsync(RegisterRequestDTO request);
    Task<AuthResponseDTO> Login(LoginRequestDTO request);
}
