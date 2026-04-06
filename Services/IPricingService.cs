using Common.Models;

namespace Services;

public interface IPricingService
{
    (StudentStatus Status, decimal FinalPrice) CalculateFinalPrice(Student student, Course course);
}
