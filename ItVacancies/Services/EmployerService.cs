using ItVacancies.Dtos;
using ItVacancies.Interfaces;
using ItVacancies.Models;

namespace ItVacancies.Services;
[AutoInterface]

public class EmployerService : IEmployerService
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IMapper _mapper;
    
    public EmployerService(IEmployerRepository employerRepository, IMapper mapper)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployerDto>> GetEmployers()
    {
        var employers = await _employerRepository.GetEmployers();
        return _mapper.Map<IEnumerable<EmployerDto>>(employers);
    }

    public async Task<EmployerDto> GetEmployer(int id)
    {
        var employer = await _employerRepository.GetEmployer(id);
        return _mapper.Map<EmployerDto>(employer);
    }
    public async Task<Employer> Create(EmployerDto employerDto)
    {
        var employer = _mapper.Map<Employer>(employerDto);
        await _employerRepository.Create(employer);
        return employer;
    }

    public async Task Update(int id, EmployerDto employerDto)
    {
        var employer = await _employerRepository.GetEmployer(id);
        if (employer == null) throw new Exception($"Employer not found");
        employer.Name = employerDto.Name;
        employer.Contacts = employerDto.Contacts;
        await _employerRepository.Update(employer);
    }

    public async Task Delete(int id)
    {
        await _employerRepository.Delete(id);
    }
}