using System.ComponentModel.DataAnnotations;

namespace Common.Models;

public sealed record InvoicePreviewRequest(
    [Range(1, int.MaxValue)] int StudentId,
    [Range(1, int.MaxValue)] int CourseId);
