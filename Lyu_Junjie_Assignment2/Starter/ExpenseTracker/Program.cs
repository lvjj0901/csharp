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
            Console.WriteLine("Add an expense,monthlyBudget="+ monthlyBudget);
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