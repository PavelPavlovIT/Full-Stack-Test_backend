using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CoursesController : ControllerBase
{
    private readonly AppDataStore _store;

    public CoursesController(AppDataStore store)
    {
        _store = store;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var courses = _store.Courses.Values.OrderBy(c => c.Id);
        return Ok(courses);
    }
}
