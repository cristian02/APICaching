using APICaching.Data;
using APICaching.Services;
using Microsoft.AspNetCore.Mvc;
using APICaching.Models;
using Microsoft.EntityFrameworkCore;

namespace APICaching.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> _logger;
    private readonly ICacheService _cacheService; 
    private readonly AppDbContext _context; 

    public StudentsController(ILogger<StudentsController> logger, ICacheService cacheService, AppDbContext context)
    {
        _logger = logger;
        _cacheService = cacheService; 
        _context = context; 
    }

    [HttpGet("Students")]
    public async Task<IActionResult> Get()
    {
        //Check cache data 
        var cacheData = _cacheService.GetData<IEnumerable<Student>>("students");
        if (cacheData != null && cacheData.Count() > 0 )
            return Ok(cacheData); 
        cacheData = await _context.Students.ToListAsync(); 
        //set expiry time 
        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<IEnumerable<Student>>("students", cacheData, expiryTime); 
        return Ok(cacheData);
    }

    [HttpPost("AddStudent")]
    public async Task<IActionResult> Post(Student value)
    {
        var addObj = await _context.Students.AddAsync(value);
        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<Student>($"students{value.Id}", addObj.Entity, expiryTime);   
        await _context.SaveChangesAsync();
        return Ok(addObj.Entity); 
    }

    [HttpDelete("DeleteStudent")]
    public async Task<IActionResult> Delete(int id)
    {
        var exist = _context.Students.FirstOrDefaultAsync(x=> x.Id == id);
        if (exist != null)
        {
            _context.Remove(exist);
            _cacheService.RemoveData($"driver{id}");
            await _context.SaveChangesAsync();
            return NoContent(); 
        }
        return NotFound(); 
    }
}
