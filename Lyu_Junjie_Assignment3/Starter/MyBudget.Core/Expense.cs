namespace MyBudget.Core;

using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "kind")]
[JsonDerivedType(typeof(OneTimeExpense), "onetime")]
[JsonDerivedType(typeof(RecurringExpense), "recurring")]
public abstract record Expense(
    Guid Id,
    string Description,
    decimal Amount,
    ExpenseCategory Category,
    DateOnly Date
) : IReportable
{
    public abstract decimal MonthlyImpact { get; }

    public virtual string ToReportLine()
    {
        return $"{Date}: {Description} - {Category} - {Amount:C}";
    }
}
