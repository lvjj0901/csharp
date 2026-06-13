Console.WriteLine("Enter a valid number(1-7):");
int num = int.Parse(Console.ReadLine());
string day = num switch
{
    1 => "MON",
    2 => "TUE",
    3 => "WED",
    4 => "THU",
    5 => "FRI",
    6 => "SAT",
    7 => "SUN",
    _ => "Enter a valid number"
};

var tmp = Enum.Parse<WeekDay>(day);
string dayDes = tmp switch
{
    WeekDay.MON => "Enum:Monday",
    WeekDay.TUE => "Enum:Tuesday",
    WeekDay.WED => "Enum:Wednesday",
    WeekDay.THU => "Enum:Thursday",
    WeekDay.FRI => "Enum:Friday",
    WeekDay.SAT or WeekDay.SUN => "Enum:Weekend",
    _ => "Invalid input"
};
Console.WriteLine(dayDes);

enum WeekDay { MON, TUE, WED, THU, FRI, SAT, SUN };
