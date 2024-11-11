using ItVacancies.Dtos;
using ItVacancies.Models;

namespace ItVacancies.Profiles;

public class ResumeProfile : Profile
{
    public ResumeProfile()
    {
        CreateMap<Resume, ResumeDto>();
        CreateMap<ResumeDto, Resume>();
    }
}