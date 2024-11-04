namespace FirstProject.Profiles;

public class ResumeProfile : Profile
{
    public ResumeProfile()
    {
        CreateMap<Resume, ResumeDto>();
        CreateMap<ResumeDto, Resume>();
    }
}