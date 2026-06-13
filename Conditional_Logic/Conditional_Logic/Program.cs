//Console.WriteLine("Hello, World!");
using System.ComponentModel;
using System.Diagnostics.Contracts;

double average = 89.9;

if (average >= 90)
{
    Console.WriteLine("Admitted - Merit scholarship egligible");
}
else if (average >= 75)
{
    Console.WriteLine("Admitted - Standard entry. Congratulation");
}
else if (average >= 60)
{
    Console.WriteLine("Conditonal admission  meet with advisor");
}
else {
    Console.WriteLine("Not Admitted!");
}

string result = average >= 60.0 ? "Pass" : "Fail";
Console.WriteLine($"Result is {result}");

//Classic Switch condition
Console.WriteLine("Enter a day number(1-7):");
int day = int.Parse(Console.ReadLine());

switch (day) {
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wensday");
        break;
    case 4:
        Console.WriteLine("Thursday");
        break;
    case 5:
        Console.WriteLine("Friday");
        break;
    //case 6:
    //    Console.WriteLine("Saturday");
    //    break;
    //case 7:
    //    Console.WriteLine("Sunday");
    //    break;
    case 6:
    case 7:
        Console.WriteLine("Weekend");
        break;
    default:
        Console.WriteLine("Invalid Number");
        break;
}

//Switch on string values

Console.WriteLine("Enter a command (start/stop/pause):");
String command = Console.ReadLine().ToLower();
switch (command) {
    case "start":
        Console.WriteLine("Starting ......");
        break;
    case "stop":
        Console.WriteLine("Stopping ......");
        break;
    case "pause":
        Console.WriteLine("Paused .......");
        break;
    default:
        Console.WriteLine("Invalid command");
        break;
}