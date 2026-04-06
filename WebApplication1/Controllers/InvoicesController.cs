using Common.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InvoicesController : ControllerBase
{
    private readonly AppDataStore _store;
    private readonly PricingService _pricing;

    public InvoicesController(AppDataStore store, PricingService pricing)
    {
        _store = store;
        _pricing = pricing;
    }

    [HttpPost("preview")]
    public IActionResult Preview([FromBody] InvoicePreviewRequest request)
    {
        if (!_store.Students.TryGetValue(request.StudentId, out var student))
            return NotFound(new { message = $"Student {request.StudentId} not found" });

        if (!_store.Courses.TryGetValue(request.CourseId, out var course))
            return NotFound(new { message = $"Course {request.CourseId} not found" });

        var (status, calculatedPrice) = _pricing.CalculateFinalPrice(student, course);

        var response = new InvoicePreviewResponse(
            student.Id,
            course.Id,
            status.ToString(),
            course.BasePrice,
            calculatedPrice);

        return Ok(response);
    }
}
