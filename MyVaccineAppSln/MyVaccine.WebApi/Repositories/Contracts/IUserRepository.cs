using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.DTOs.Request;

namespace MyVaccine.WebApi.Repositories.Contracts;

public interface IUserRepository
{
    Task<IdentityResult> AddUser(RegisterRequestDTO request);
}
