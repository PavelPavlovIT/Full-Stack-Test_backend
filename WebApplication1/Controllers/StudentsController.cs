using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class StudentsController : ControllerBase
{
    private readonly AppDataStore _store;

    public StudentsController(AppDataStore store)
    {
        _store = store;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _store.Students.Values.OrderBy(s => s.Id);
        return Ok(students);
    }
}
