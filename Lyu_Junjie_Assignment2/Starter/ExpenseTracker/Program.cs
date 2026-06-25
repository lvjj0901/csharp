// =====================================================================
//  Program.cs  —  the interactive console UI for MyBudget (Assignment 1).
//  Target framework: .NET 10 (LTS), language C# 14.
//
//  >>> BUILD THE MENU-DRIVEN UI HERE (Modules 1-3). <<<
//
//  Once you have implemented BudgetRules.cs (so the unit tests pass), wire it
//  up to a console interface that meets the assignment brief:
//
//    * Print a banner (try a raw string literal).
//    * Loop a menu until the user exits, using a switch on the choice:
//        1) Add an expense   2) View summary   3) Set monthly budget   4) Exit
//    * Read and VALIDATE input, re-prompting on bad data (decimal.TryParse,
//      BudgetRules.NormalizeCategory, a date parse, non-empty text).
//    * Keep running totals in simple variables (no collections / no classes).
//    * Use BudgetRules.ValidateAmount / ClassifyAmount / BudgetStatus /
//      FormatCurrency for all logic and formatting.
//    * Handle bad input with try / catch / finally and InvalidExpenseException.
//
//  See section 6 of the assignment brief for a sample run to aim for.
// =====================================================================
using ExpenseTracker;
using System.Runtime.CompilerServices;
string bannerUI = """
    ============================================================
                    MyBudget Expense Tracker
    ============================================================
    """;
Console.WriteLine(bannerUI);
decimal? monthlyBudget = null;


int expenseCount = 0;
decimal totalSpent = 0.0m;
decimal maxExpense = 0.0m;

decimal foodSpent = 0.0m;
decimal transportSpent = 0.0m;
decimal utilitiesSpent = 0.0m;
decimal entertainmentSpent = 0.0m;
decimal otherSpent = 0.0m;

string category = "";
bool exitFlag = false;
while (!exitFlag)
{
    string menuUI = """ 


                    1) Add an expense  2) View summary  3) Set monthly budget  4) Exit
                    """;
    Console.WriteLine(menuUI);
    Console.Write("> ");
    string menu = Console.ReadLine();
    int menuChoice;
    bool checkMenuChoice = false;
    do
    {
        while (!int.TryParse(menu, out menuChoice))
        {
            Console.WriteLine("Invalid input. Please enter a number(1-4): ");
            Console.Write("> ");
            menu = Console.ReadLine();
        }

        if (menuChoice > 0 && menuChoice < 5)
        {
            checkMenuChoice = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number(1-4): ");
            Console.Write("> ");
            menu = Console.ReadLine();
            checkMenuChoice = false;
        }
    } while (!checkMenuChoice);

    switch (menuChoice)
    {
        case 1:
            AddExpense();
            break;
        case 2:
            ViewSummary();
            break;
        case 3:
            SetMonthlyBudget();
            break;
        case 4:
            Console.WriteLine("See you later!");
            exitFlag = true;
            break;
    }
}

void AddExpense()
{
    //check description and store description
    bool checkInput = false;
    string input;
    Console.Write("Description : ");
    do
    {
        input = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Please enter a valid description: ");
            Console.Write("> ");
            input = Console.ReadLine();
        }
        checkInput = true;
    } while (!checkInput);

    //check amount and store amount
    decimal amount;
    Console.Write("Amount      : ");
    input = Console.ReadLine();
    do
    {
        while (!decimal.TryParse(input, out amount))
        {
            Console.Write("Invalid input. Please enter a valid amount: ");
            input = Console.ReadLine();
        }
        try
        {
            amount = BudgetRules.ValidateAmount(amount);
            checkInput = true;
        }
        catch (InvalidExpenseException ex)
        {
            Console.WriteLine(ex.Message);
            Console.Write("Please enter a valid amount: ");
            input = Console.ReadLine();
            checkInput = false;
        }
    } while (!checkInput);

    //check category and store category
    Console.Write("Category    : [Food/Transport/Utilities/Entertainment/Other] ");
    input = Console.ReadLine();
    do
    {
        category = BudgetRules.NormalizeCategory(input);
        while(string.IsNullOrWhiteSpace(category))
        {
            Console.WriteLine("Please enter a valid category: ");
            Console.Write("> ");
            input = Console.ReadLine();
            category = BudgetRules.NormalizeCategory(input);
        }
        checkInput = true;
    } while (!checkInput);

    //check date and store date
    Console.Write("Date (blank = today or entered as yyyy-mm-dd):");
    input = Console.ReadLine();
    DateTime date;
    do
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            date = DateTime.Today;
            Console.WriteLine($"Date set to {date:yyyy-MM-dd}");
            checkInput = true;
        }
        else if (DateTime.TryParse(input, out date))
        {
            Console.WriteLine($"Date set to {date:yyyy-MM-dd}");
            checkInput = true;
        }
        else
        {
            Console.Write("Invalid input. Please enter a valid date (yyyy-mm-dd): ");
            input = Console.ReadLine();
            checkInput = false;
        }
    } while (!checkInput);

    //check note and store note
    Console.Write("Note (optional): ");
    string? note = Console.ReadLine();

    expenseCount++;
    totalSpent += amount;
    if (amount > maxExpense)
    {
        maxExpense = amount;
    }

    switch (category)
    {
        case "Food":
            foodSpent += amount;
            break;
        case "Transport":
            transportSpent += amount;
            break;
        case "Utilities":
            utilitiesSpent += amount;
            break;
        case "Entertainment":
            entertainmentSpent += amount;
            break;
        case "Other":
            otherSpent += amount;
            break;
    }
    if (monthlyBudget.HasValue)
    {
        string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget.Value - totalSpent, monthlyBudget.Value);
        Console.WriteLine($"    Recorded: {BudgetRules.FormatCurrency(amount)} | {category} | {date:yyyy-MM-dd}");
        Console.WriteLine($"  Size band : {BudgetRules.ClassifyAmount(amount)}");
        Console.WriteLine($"      Budget: {BudgetRules.FormatCurrency(monthlyBudget.Value - totalSpent)} remaining of {BudgetRules.FormatCurrency(monthlyBudget.Value)} -> {budgetStatus}");
    }
    else
    {
        Console.WriteLine($"    Recorded: {BudgetRules.FormatCurrency(amount)} | {category} | {date:yyyy-MM-dd}");
        Console.WriteLine($"  Size band : {BudgetRules.ClassifyAmount(amount)}");
    }
}
void ViewSummary()
{
    if (expenseCount == 0)
    {
        Console.WriteLine("No expenses recorded yet.");
        return;
    }

    Console.WriteLine($"Number of expenses: {expenseCount}");
    Console.WriteLine($"Total spent: {BudgetRules.FormatCurrency(totalSpent)}");
    Console.WriteLine($"Average of expenses: {BudgetRules.FormatCurrency(totalSpent/expenseCount)}");
    Console.WriteLine($"Highest single expense: {BudgetRules.FormatCurrency(maxExpense)}");

    Console.WriteLine($"Food: {BudgetRules.FormatCurrency(foodSpent)}");
    Console.WriteLine($"Transport: {BudgetRules.FormatCurrency(transportSpent)}");
    Console.WriteLine($"Utilities: {BudgetRules.FormatCurrency(utilitiesSpent)}");
    Console.WriteLine($"Entertainment: {BudgetRules.FormatCurrency(entertainmentSpent)}");
    Console.WriteLine($"Other: {BudgetRules.FormatCurrency(otherSpent)}");

    if(monthlyBudget.HasValue)
    {
        string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget.Value - totalSpent, monthlyBudget.Value);
        Console.Write($"  Budget: {BudgetRules.FormatCurrency(monthlyBudget.Value - totalSpent)} remaining of {BudgetRules.FormatCurrency(monthlyBudget.Value)} -> {budgetStatus}");
    }
}
void SetMonthlyBudget()
{
    if (!monthlyBudget.HasValue)
    {
        Console.Write("Monthly budget:");
        string input = Console.ReadLine();
        bool checkMonthlyBudget = false;
        do
        {
            decimal value;
            while (!decimal.TryParse(input, out value))
            {
                Console.Write("Invalid input. Please enter a valid amount: ");
                Console.Write("> ");
                input = Console.ReadLine();
            }
            try
            {
                monthlyBudget = BudgetRules.ValidateAmount(value);
                string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget.Value - totalSpent, monthlyBudget.Value);
                Console.WriteLine($"Budget set to {BudgetRules.FormatCurrency(monthlyBudget.Value)}");
                Console.Write($"  Budget: {BudgetRules.FormatCurrency(monthlyBudget.Value - totalSpent)} remaining of {BudgetRules.FormatCurrency(monthlyBudget.Value)} -> {budgetStatus}");
                checkMonthlyBudget = true;
            }
            catch (InvalidExpenseException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Please enter a valid amount: ");
                Console.Write("> ");
                input = Console.ReadLine();
                checkMonthlyBudget = false;
            }
        } while (!checkMonthlyBudget);
    }
    else
    {
        string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget.Value - totalSpent, monthlyBudget.Value);
        Console.Write($"  Budget: {BudgetRules.FormatCurrency(monthlyBudget.Value - totalSpent)} remaining of {BudgetRules.FormatCurrency(monthlyBudget.Value)} -> {budgetStatus}");
    }
}