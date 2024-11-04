namespace FirstProject.DataAccess;

public class EmployerRepository : IEmployerRepository
{
    private readonly DataContext _context;

    public EmployerRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Employer>> GetEmployers()
    {
        return await _context.Employers.ToListAsync();
    }
    
    public async Task<Employer> GetEmployer(int id)
    {
        return await _context.Employers.FindAsync(id);
    }

    public async Task Create(Employer employer)
    {
        _context.Employers.Add(employer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Employer employer)
    {
        _context.Employers.Update(employer);
        await _context.SaveChangesAsync();    
    }

    public async Task Delete(int id)
    {
        var employer = await _context.Employers.FindAsync(id);
        if (employer != null)
        {
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();
        }
    }
}