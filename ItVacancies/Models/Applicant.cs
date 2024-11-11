using ItVacancies.Models.Base;

namespace ItVacancies.Models
{
    public class Applicant : BaseModel
    {
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string Description { get; set; }
        public ICollection<Resume> Resumes { get; set; }

    }
}
