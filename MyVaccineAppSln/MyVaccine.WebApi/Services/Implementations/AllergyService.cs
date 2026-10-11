using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.DTOs.Request;
using MyVaccine.WebApi.DTOs.Response;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class AllergyService : IAllergyService
{
    private readonly IBaseRepository<Allergy> _allergyRepository;
    private readonly IMapper _mapper;

    public AllergyService(IBaseRepository<Allergy> allergyRepository, IMapper mapper)
    {
        _allergyRepository = allergyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AllergyResponseDTO>> GetAll()
    {
        var allergies = await _allergyRepository.GetAll().Include(a => a.User).AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<AllergyResponseDTO>>(allergies);

        return response;
    }

    public async Task<AllergyResponseDTO> GetById(int id)
    {
        var allergy = await _allergyRepository.FindByAsNoTracking(a => a.Id == id).Include(a => a.User).FirstOrDefaultAsync();
        var response = _mapper.Map<AllergyResponseDTO>(allergy);

        return response;
    }

    public async Task<IEnumerable<AllergyResponseDTO>> GetAllergiesByUserId(int userId)
    {
        var allergies = await _allergyRepository.FindByAsNoTracking(a => a.UserId == userId).Include(a => a.User).ToListAsync();
        var response = _mapper.Map<IEnumerable<AllergyResponseDTO>>(allergies);

        return response;
    }

    public async Task<AllergyResponseDTO> Add(AllergyRequestDTO request)
    {
        // var allergy = await _allergyRepository.FindBy(a => a.Id == id).FirstOrDefaultAsync();
        var allergy = new Allergy();
        allergy.Name = request.Name;
        allergy.UserId = request.UserId;

        await _allergyRepository.Add(allergy);
        var allergyWithUser = await _allergyRepository.FindBy(a => a.Id == allergy.Id).Include(a => a.User).FirstOrDefaultAsync();
        var response = _mapper.Map<AllergyResponseDTO>(allergyWithUser);

        return response;
    }

    public async Task<AllergyResponseDTO> Delete(int id)
    {
        var allergy = await _allergyRepository.FindBy(a => a.Id == id).Include(a => a.User).FirstOrDefaultAsync();

        await _allergyRepository.Delete(allergy);
        var response = _mapper.Map<AllergyResponseDTO>(allergy);

        return response;
    }

    public async Task<AllergyResponseDTO> Update(int id, AllergyRequestDTO request)
    {
        var allergy = await _allergyRepository.FindBy(a => a.Id == id).Include(a => a.User).FirstOrDefaultAsync();
        allergy.Name = request.Name;
        allergy.UserId = request.UserId;

        await _allergyRepository.Update(allergy);
        var response = _mapper.Map<AllergyResponseDTO>(allergy);

        return response;
    }
}
