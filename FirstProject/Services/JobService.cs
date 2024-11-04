namespace FirstProject.Services;
[AutoInterface]
public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public JobService(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<JobDto>> GetJobs()
    {
        var jobs = await _jobRepository.GetJobs();
        return _mapper.Map<IEnumerable<JobDto>>(jobs);
    }

    public async Task<JobDto> GetJob(int id)
    {
        var job = await _jobRepository.GetJob(id);
        return _mapper.Map<JobDto>(job);
    }

    public async Task<Job> Create(JobDto jobdto)
    {
        var job = _mapper.Map<Job>(jobdto);
        await _jobRepository.Create(job);
        return job;
    }
    public async Task Update(int id, JobDto jobDto)
    {
        var existingJob = await _jobRepository.GetJob(id);
        if (existingJob == null)  throw new KeyNotFoundException($"Job with ID {id} not found.");
        existingJob.Title = jobDto.Title;
        existingJob.Description = jobDto.Description;
        existingJob.Skills = jobDto.Skills;
        existingJob.ProgrammingLanguage = jobDto.ProgrammingLanguage;
        await _jobRepository.Update(existingJob);
    }

    public async Task Delete(int id)
    {
        await _jobRepository.Delete(id);
    }
    
}