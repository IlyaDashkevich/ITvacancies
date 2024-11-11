using ItVacancies.Dtos;
using ItVacancies.Interfaces;
using ItVacancies.Models;

namespace ItVacancies.Services;

[AutoInterface]

public class ResumeService : IResumeService
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IMapper _mapper;

    public ResumeService(IResumeRepository resumeRepository, IMapper mapper)
    {
        _resumeRepository = resumeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ResumeDto>> GetAll()
    {
        var resumes = await _resumeRepository.GetAll();
        return _mapper.Map<IEnumerable<ResumeDto>>(resumes);
    }

    public async Task<ResumeDto> GetById(int id)
    {
        var resume = await _resumeRepository.GetById(id);
        return _mapper.Map<ResumeDto>(resume);
    }

    public async Task<Resume> Create(ResumeDto resumeDto)
    {
        var resume = _mapper.Map<Resume>(resumeDto);
        await _resumeRepository.Create(resume);
        return resume;
    }

    public async Task Update(int id, ResumeDto resumeDto)
    {
        var existingResume = await _resumeRepository.GetById(id);
        if (existingResume == null)  throw new KeyNotFoundException($"Job with ID {id} not found.");
        existingResume.Name = resumeDto.Name;
        existingResume.Skills = resumeDto.Skills;
        existingResume.Experience = resumeDto.Experience;
        existingResume.Education = resumeDto.Education;
        await _resumeRepository.Update(existingResume);
    }

    public async Task Delete(int id)
    {
        await _resumeRepository.Delete(id);
    }
}