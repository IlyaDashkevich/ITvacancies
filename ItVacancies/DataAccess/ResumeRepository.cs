using ItVacancies.Interfaces;
using ItVacancies.Models;

namespace ItVacancies.DataAccess;

public class ResumeRepository : IResumeRepository
{
    private readonly DataContext _context;

    public ResumeRepository(DataContext context)
    {   
        _context = context;
    }

    public async Task <IEnumerable<Resume>> GetAll() 
    {
        return await _context.Resumes.ToListAsync();
    }
    
    public async Task<Resume> GetById(int id)
    {
        return await _context.Resumes.FindAsync(id); 
    }

    public async Task Create(Resume resume)
    { 
        _context.Resumes.Add(resume);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Resume resume)
    {
        _context.Resumes.Update(resume);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var resume = await _context.Resumes.FindAsync(id);
        if (resume == null)
        {
            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
        }
    }
}