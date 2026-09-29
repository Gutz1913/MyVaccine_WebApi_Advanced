using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.DTOs;

namespace MyVaccine.WebApi.Repositories.Contracts;

public interface IUserRepository
{
    Task<IdentityResult> AddUser(RegisterRequestDTO request);
}
