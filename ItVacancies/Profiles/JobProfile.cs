using ItVacancies.Dtos;
using ItVacancies.Models;

namespace ItVacancies.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDto>();
        CreateMap<JobDto, Job>();
    }
}