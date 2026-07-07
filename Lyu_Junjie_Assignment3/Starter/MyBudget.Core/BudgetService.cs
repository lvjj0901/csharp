namespace MyBudget.Core;

public class BudgetService : IBudgetService
{
    //encapsulated state
    public decimal MonthlyLimit { get; private set; }

    public void SetMonthlyLimit(decimal limit)
    {
        if (limit <= 0)
            throw new InvalidExpenseException("Invalid limit.");

        MonthlyLimit = Math.Round(limit, 2);
    }

    public decimal Remaining(decimal totalSpent)
    {
        return MonthlyLimit - totalSpent;
    }

    public BudgetStatus Evaluate(decimal totalSpent)
    {
        if (MonthlyLimit == 0)
            return BudgetStatus.NotSet;

        decimal remaining = Remaining(totalSpent);

        if (remaining < 0)
            return BudgetStatus.OverBudget;

        if (remaining < MonthlyLimit * 0.1m)
            return BudgetStatus.AlmostOut;

        return BudgetStatus.OnTrack;
    }
}
