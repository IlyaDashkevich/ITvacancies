using ItVacancies.Models;

namespace ItVacancies.Interfaces;

public interface IEmployerRepository
{
    Task<IEnumerable<Employer>> GetEmployers();
    Task<Employer> GetEmployer(int id);
    Task Create (Employer employer);
    Task Update (Employer employer);
    Task Delete(int id);
}