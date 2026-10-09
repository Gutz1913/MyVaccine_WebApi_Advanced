using MyVaccine.WebApi.DTOs.Request;
using MyVaccine.WebApi.DTOs.Response;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDTO> AddUserAsync(RegisterRequestDTO request);
    Task<AuthResponseDTO> Login(LoginRequestDTO request);
}
