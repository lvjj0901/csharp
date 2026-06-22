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
string menuUI = """
    ============================================================
                    MyBudget Expense Tracker
    ============================================================

    1) Add an expense  2) View summary  3) Set monthly budget  4) Exit
    
    """;
Console.WriteLine(menuUI);

// Delete the line above and implement the application here.
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

    if (menuChoice >0 && menuChoice < 5)
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
        Console.WriteLine("Add an expense");
        break;
    case 2:
        Console.WriteLine("View summary");
        break;
    case 3:
        SetMonthlyBudget();
        break;
    case 4:
        Console.WriteLine("See you later!");
        Environment.Exit(0);
        break;
}

void SetMonthlyBudget()
{
    Console.WriteLine("Monthly budget:");
    string input = Console.ReadLine();
    decimal monthlyBudget;
    bool checkMonthlyBudget = false;
    do
    {
        while (!decimal.TryParse(input, out monthlyBudget))
        {
            Console.WriteLine("Invalid input. Please enter a valid amount: ");
            Console.Write("> ");
            input = Console.ReadLine();
        }
        try
        {
            monthlyBudget = BudgetRules.ValidateAmount(monthlyBudget);
            checkMonthlyBudget = true;
        }
        catch (InvalidExpenseException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Please enter a valid amount: ");
            Console.Write("> ");
            input = Console.ReadLine();
            checkMonthlyBudget = false;
        }
    } while (!checkMonthlyBudget);
}