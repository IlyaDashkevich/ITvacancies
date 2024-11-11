using ItVacancies.Dtos;
using ItVacancies.Services;

namespace ItVacancies.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResumeController : Controller
{
    private readonly IResumeService _resumeService;

    public ResumeController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resumes = await _resumeService.GetAll();
        return Ok(resumes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var resume = await _resumeService.GetById(id);
        if (resume == null) return NotFound();
        
        return Ok(resume);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ResumeDto resumeDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var resume = await _resumeService.Create(resumeDto);
        return Ok(resume);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ResumeDto resumeDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var existingResume = await _resumeService.GetById(id);
        if (existingResume == null) return NotFound();

        await _resumeService.Update(id, resumeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resume = await _resumeService.GetById(id);
            if (resume == null) return NotFound();
            
            await _resumeService.Delete(id);
            return NoContent(); 
        }
}