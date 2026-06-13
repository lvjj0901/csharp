//Student name: Junjie(Jason) Lyu  Student ID: N01793658

string[] inputs = { "principal", "annual interest(%)", "compounding frequency per year", "number of years" };
double[] data = { 0.0, 0.0, 0.0, 0.0 };
bool check = false;

for (int i = 0; i < inputs.Length; i++)
{
    Console.WriteLine($"Enter {inputs[i]}(input>0):");
    string tmp = Console.ReadLine();

    if (i < (inputs.Length - 2))
    {
        check = double.TryParse(tmp, out double inputDouble);
        while (!check)
        {
            Console.WriteLine($"Enter a valid {inputs[i]}(input>0):");
            tmp = Console.ReadLine();
            check = double.TryParse(tmp, out inputDouble);

            if (inputDouble < 0.0)
            {
                check = false;
            }
        }
        data[i] = inputDouble;
    }
    else
    {
        check = int.TryParse(tmp, out int inputInt);
        while (!check)
        {
            Console.WriteLine($"Enter a valid {inputs[i]}(input>0):");
            tmp = Console.ReadLine();
            check = int.TryParse(tmp, out inputInt);

            if (inputInt < 0)
            {
                check = false;
            }
        }
        data[i] = inputInt;
    }
    
}

double principal = data[0];
double annualInterest = data[1]/100;
int compounding = (int)data[2];
int numberOfYears = (int)data[3];

string head = $"""

                === Compound Interest Calculator ===
                Principal:    {principal:C2}
                Rate:         {data[1]:F2}%
                Compounding:  {compounding} times/year
                -----------------------------------
                Year    Balance
                -----------------------------------
                """;
Console.WriteLine(head);

double finalBalance = 0.0;
//A = P * Math.Pow(1 + r/n, n*t)
for (int i = 1; i <= numberOfYears; i++)
{
    double balance = principal * Math.Pow(1 + annualInterest / compounding, compounding * i);
    Console.WriteLine($"{i}       {balance:C2}");
    if (i == numberOfYears) 
    {
        finalBalance = balance;
    }
}
double totalInterest = finalBalance - principal;
string tail = $"""
                -----------------------------------
                Initial Investment:  {principal:C2}
                Total Interest:        {(finalBalance - principal):C2}
                Final Balance:       {finalBalance:C2}
                """;
Console.WriteLine(tail);