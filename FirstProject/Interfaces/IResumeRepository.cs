namespace FirstProject.Interfaces;

public interface IResumeRepository
{
    Task <IEnumerable<Resume>> GetAll(); 
    Task <Resume> GetById (int id);
    Task Create (Resume resume);
    Task Update (Resume resume);
    Task Delete (int id);
    
}