namespace Common.Models;

public sealed record InvoicePreviewResponse(
    int StudentId,
    int CourseId,
    string Status,
    decimal BasePrice,
    decimal CalculatedPrice);
