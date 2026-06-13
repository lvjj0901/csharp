//Student name: Junjie(Jason) Lyu  Student ID: N01793658
const int tem = 32;

string menu = """
    === Temperature Converter ===
    1. Celsius to Fahrenheit
    2. Fahrenheit to Celsius
    Enter your choice (1 or 2):
    """;
Console.WriteLine(menu);

string input = Console.ReadLine();
bool checkInput = int.TryParse(input, out int option);

//check flag for temperature input
bool checkType = false;

//-	Option 1: Celsius to Fahrenheit — Formula: F = (C × 9/5) + 32
if ((option == 1) && checkInput) 
{
    Console.WriteLine("Enter temperature in Celsius: ");
    string celsius = Console.ReadLine();
    checkType = double.TryParse(celsius, out double celsiusNum);
    if (checkType)
    {
        double fah = (celsiusNum * 9 / 5) + tem;
        Console.WriteLine($"Result: {celsiusNum:F2} degrees Celsius = {fah:F2} degrees Fahrenheit");
    }
    else 
    {
        Console.WriteLine("Enter a valid celsius number.");
    }
}
//-Option 2: Fahrenheit to Celsius — Formula: C = (F - 32) × 5 / 9
else if((option == 2) && checkInput)
{
    Console.WriteLine("Enter temperature in fahrenheit: ");
    string fahrenheit = Console.ReadLine();
    checkType = double.TryParse(fahrenheit, out double fahrenheitNum);
    if (checkType)
    {
        double cel = (fahrenheitNum - tem) * 5 / 9;
        Console.WriteLine($"Result: {fahrenheitNum:F2} degrees Fahrenheit = {cel:F2} degrees Celsius");
    }
    else
    {
        Console.WriteLine("Enter a valid fahrenheit number.");
    }
}
else
{
    Console.WriteLine("Enter a valid number 1 or 2.");
}

