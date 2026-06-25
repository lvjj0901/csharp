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
decimal monthlyBudget = 0.0m;
decimal expense = 0.0m;
decimal[] foodExpenses = new decimal[31];
decimal[] transportExpenses = new decimal[31];
decimal[] utilitiesExpenses = new decimal[31];
decimal[] entertainmentExpenses = new decimal[31];
decimal[] otherExpenses = new decimal[31];
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
            Console.WriteLine("View summary");
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
    string input = "";
    do
    {
        Console.Write("Description : ");
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Please enter a valid description: ");
            input = Console.ReadLine();
            checkInput = false;
        }
        else
        {
            checkInput = true;
        }
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
            expense += amount;
            //string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget - expense, monthlyBudget);
            //Console.WriteLine($"Expense added: {amount:C2}");
            //Console.WriteLine($"  Budget: {monthlyBudget - expense:C2} remaining of {monthlyBudget:C2} -> {budgetStatus}");
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
        try
        {
            category = BudgetRules.NormalizeCategory(input);
            Console.WriteLine($"Category set to {category}");
            checkInput = true;
        }
        catch (InvalidExpenseException ex)
        {
            Console.WriteLine(ex.Message);
            Console.Write("Please enter a valid category: ");
            input = Console.ReadLine();
            checkInput = false;
        }
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

    Console.WriteLine($"    Recorded: {amount:C2} | {category} | {date:yyyy-MM-dd}");
    Console.WriteLine($"  Size band : {BudgetRules.ClassifyAmount(amount)}");
    Console.WriteLine($"      Budget: {monthlyBudget - expense:C2} remaining of {monthlyBudget:C2} -> ");
}

void SetMonthlyBudget()
{
    Console.Write("Monthly budget:");
    string input = Console.ReadLine();
    bool checkMonthlyBudget = false;
    do
    {
        while (!decimal.TryParse(input, out monthlyBudget))
        {
            Console.Write("Invalid input. Please enter a valid amount: ");
            Console.Write("> ");
            input = Console.ReadLine();
        }
        try
        {
            monthlyBudget = BudgetRules.ValidateAmount(monthlyBudget);
            string budgetStatus = BudgetRules.BudgetStatus(monthlyBudget-expense,monthlyBudget);
            Console.WriteLine($"Budget set to {monthlyBudget:C2}");
            Console.Write($"  Budget: {monthlyBudget - expense:C2} remaining of {monthlyBudget:C2} -> {budgetStatus}");
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