using Common.Models;

namespace Services;

public sealed class PricingService
{
    public (StudentStatus Status, decimal FinalPrice) CalculateFinalPrice(Student student, Course course)
    {
        var status = GetStatus(student.PreviousEnrollments);

        var premiumByStatus = course.IsPremium
            ? status switch
            {
                StudentStatus.New => 1.2m,
                StudentStatus.Returning => 1.1m,
                StudentStatus.VIP => 0.5m,
                _ => 1.0m
            }
            : 1.0m;

        var ageModifier = student.Age < 18 ? 0.8m : 1.0m;
        var prevEnrollmentsModifier = student.PreviousEnrollments > 0 ? 0.9m : 1.0m;

        var finalPrice = course.BasePrice * premiumByStatus * ageModifier * prevEnrollmentsModifier;
        finalPrice = Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);

        if (finalPrice < 0)
            finalPrice = 0;

        return (status, finalPrice);
    }

    private static StudentStatus GetStatus(int previousEnrollments)
    {
        if (previousEnrollments <= 0)
            return StudentStatus.New;

        if (previousEnrollments <= 2)
            return StudentStatus.Returning;

        return StudentStatus.VIP;
    }
}
