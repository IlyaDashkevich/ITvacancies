namespace ItVacancies.Models.Base;

public class File : BaseModel
{
    public string Name { get; set; }
    public string Path { get; set; }
    public Resume Resume { get; set; }
    public int ResumeId { get; set; }
}