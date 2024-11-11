using ItVacancies.DataAccess;
using ItVacancies.Helpers;

namespace ItVacancies.Services;

[AutoInterface]
public class FileService : IFileService
{
    private readonly DataContext _context;
    
    public FileService(DataContext context)
    {
        _context = context;
    }
 
    public async Task<File?> GetFileById(int id)
    {
        return await _context.Files.FindAsync(id);
    }

    public async Task<File> FileUpload(int resumeId, IFormFile file)
    {
        var resume = await _context.Resumes.FindAsync(resumeId);
        if (resume == null) throw new KeyNotFoundException($"Resume with Id:{resumeId} not found");

        var allowedExtensions = ExtensionHelper.GetAllowedExtensions();
        var extension = Path.GetExtension(file.FileName);
        if (!allowedExtensions.Contains(extension))
        {
            return null;
        }
        var fileName = file.FileName;
        var filePath = Path.Combine("files", file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var fileDb = new File
        {
            Name = fileName,
            Path = filePath,
            ResumeId = resumeId,
            Resume = resume
        };

        _context.Files.Add(fileDb);
        await _context.SaveChangesAsync();

        return fileDb;
    } 

    public async Task DeleteFile(int id)
    {
        var file = await _context.Files.FindAsync(id);
        if (file != null)
        {
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
    
}