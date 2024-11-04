namespace FirstProject.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>();
        CreateMap<JobDto, Job>();
    }
}