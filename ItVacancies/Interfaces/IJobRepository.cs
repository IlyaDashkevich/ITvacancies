using ItVacancies.Models;

namespace ItVacancies.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJob(int id); 
        Task Create(Job job);
        Task Update(Job job);
        Task Delete(int id);
    }
}
