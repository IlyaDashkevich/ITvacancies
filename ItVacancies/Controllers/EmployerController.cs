using ItVacancies.Dtos;
using ItVacancies.Services;

namespace ItVacancies.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EmployerController : Controller
{
    private readonly IEmployerService _employerService;

    public EmployerController(IEmployerService employerService)
    {
        _employerService = employerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployers()
    {
        var employers = await _employerService.GetEmployers();
        return Ok(employers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployer(int id)
    {
        var employer = await _employerService.GetEmployer(id);
        if (employer == null) NotFound();
        
        return Ok(employer);
    }
    [HttpPost]
    public async Task<IActionResult> Create(EmployerDto employerDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var employer = await _employerService.Create(employerDto);
            return Ok(employer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,EmployerDto employerDto)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
          
        var employer = await _employerService.GetEmployer(id);
        if(employer == null) return NotFound();
        
        await _employerService.Update(id,employerDto);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employer = await _employerService.GetEmployer(id);
        if (employer == null) return NotFound();
        
        await _employerService.Delete(id);
        return NoContent();
    }
}