using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.DTOs.Request;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly MyVaccineAppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public UserRepository(MyVaccineAppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddUser(RegisterRequestDTO request)
    {
        var user = new IdentityUser
        {
            UserName = request.UserName,
            Email = request.Email
        };

        //var result = await _userManager.CreateAsync(user, request.Password);
        return null!;
    }
}
