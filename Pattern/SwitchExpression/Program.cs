Console.WriteLine("Enter a valid number(1-7):");

int num = int.Parse(Console.ReadLine());

string day = num switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    4 => "Thursday",
    5 => "Friday",
    6 or 7 => "Weekend",
    _ => "Enter a valid number"
};

Console.WriteLine("day = " + day);