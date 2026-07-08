using MyBudget.Core;
using Xunit;

namespace MyBudget.Tests;

public class BudgetServiceCustomTests
{
    [Fact]
    public void SetMonthlyLimit_RoundsToTwoDecimals()
    {
        // Arrange
        var service = new BudgetService();

        // Act
        service.SetMonthlyLimit(100.567m);

        // Assert
        Assert.Equal(100.57m, service.MonthlyLimit);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void SetMonthlyLimit_InvalidLimit_ThrowsException(decimal limit)
    {
        // Arrange
        var service = new BudgetService();

        // Act + Assert
        Assert.Throws<InvalidExpenseException>(() =>
            service.SetMonthlyLimit(limit));
    }

    [Fact]
    public void Evaluate_WhenLessThanTenPercentRemaining_ReturnsAlmostOut()
    {
        // Arrange
        var service = new BudgetService();
        service.SetMonthlyLimit(1000m);

        // Act
        var result = service.Evaluate(950m);

        // Assert
        Assert.Equal(BudgetStatus.AlmostOut, result);
    }
}
