//Student name: Junjie(Jason) Lyu  Student ID: N01793658

Console.WriteLine("Enter 10 integers:");

int[] numbers = new int[10];
bool check = false;
int sum = 0;
int max = 0;
int min = 0;
int even = 0;
int odd = 0;
int positive = 0;
int negative = 0;
int zero = 0;
for (int i = 1; i < 11; i++)
{
    Console.Write($"Number {i}: ");
    string tmp = Console.ReadLine();

    check = int.TryParse(tmp, out int inputInt);
    while (!check)
    {
        Console.Write($"Enter a valid Number {i}: ");
        tmp = Console.ReadLine();
        check = int.TryParse(tmp, out inputInt);
    }
    numbers[i-1] = inputInt;

    //get max and min
    if (i != 1)
    {
        max = inputInt > max ? inputInt : max;
        min = inputInt < min ? inputInt : min;
    }
    else
    {
        max = inputInt;
        min = inputInt;
    }

    //get even count and odd count
    if (inputInt % 2 == 0)
    {
        even++;
    }
    else
    {
        odd++;
    }

    //get count of positive numbers, count of negative numbers， count of zeros
    if (inputInt > 0)
    {
        positive++;
    } 
    else if (inputInt == 0)
    {
        zero++;
    }
    else
    {
        negative++;
    }

    //get sum
    sum += inputInt;
}

string head = $"""

                === Analysis ===
                Sum:           {sum}
                Average:       {sum/10.0:F2}
                Maximum:       {max}
                Minimum:       {min}
                Even count:    {even}
                Odd count:     {odd}
                Positive:      {positive}
                Negative:      {negative}
                Zeros:         {zero}
   
                === Visual ===
                """;
Console.WriteLine(head);
foreach (int i in numbers)
{
    if (i >= 0)
    {
        Console.Write($"{i,3}: ");
        for (int j = 0; j < i; j++)
        {
            if (j < 20) 
            {
                Console.Write("*");
            }
            
        }
    }
    else 
    {
        Console.Write($"{i,3}: -");
        for (int j = 0; j < Math.Abs(i); j++)
        {
            if (j < 20)
            {
                Console.Write("*");
            }
        }
    }
    Console.WriteLine();
}