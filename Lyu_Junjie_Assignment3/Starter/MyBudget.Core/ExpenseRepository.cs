namespace MyBudget.Core;

public class ExpenseRepository : IExpenseRepository
{
    private List<Expense> _expenses;
    private IExpenseStore _store;

    public ExpenseRepository(IExpenseStore store)
    {
        _store = store;
        _expenses = store.Load().ToList();
    }
    public void Add(Expense expense)
    {
        if (expense == null) 
        {
            throw new InvalidExpenseException("Expense cannot be null");
        }
        _expenses.Add(expense);
    }

    public IReadOnlyList<Expense> GetAll()
    {
        return _expenses.OrderBy(e => e.Date).ToList();
    }

    public IReadOnlyList<Expense> InCategory(ExpenseCategory category)
    {
        return _expenses.Where(e => e.Category == category).OrderBy(e => e.Date).ToList();
    }

    public void Save()
    {
        _store.Save(_expenses);
    }

    public decimal Total()
    {
        return _expenses.Sum(e => e.MonthlyImpact);
    }

    public IReadOnlyDictionary<ExpenseCategory, decimal> TotalsByCategory()
    {
        return _expenses.GroupBy(e => e.Category).ToDictionary(g => g.Key, g => g.Sum(e => e.MonthlyImpact));
    }
}
