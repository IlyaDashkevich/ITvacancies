namespace FirstProject.DataAccess;
public class JobRepository : IJobRepository
{
    private readonly DataContext _jobContext;
    public JobRepository(DataContext jobContext)
    {
        _jobContext = jobContext;
    }

    public async Task<IEnumerable<Job>> GetJobs()
    {
        return await _jobContext.Jobs.ToListAsync();
    }

    public async Task<Job> GetJob(int id)
    {
        return await _jobContext.Jobs.FindAsync(id);
    }

    public async Task Create (Job job)
    {
        _jobContext.Jobs.Add(job);
        await _jobContext.SaveChangesAsync();
    }
    
    public async Task Update (Job job)
    {  
        _jobContext.Jobs.Update(job);
        await _jobContext.SaveChangesAsync();
    }
    
    public async Task Delete (int id)
    {
        var job = await _jobContext.Jobs.FindAsync(id);
        if (job != null)
        {
            _jobContext.Jobs.Remove(job);
            await _jobContext.SaveChangesAsync();
        }
    }
}

