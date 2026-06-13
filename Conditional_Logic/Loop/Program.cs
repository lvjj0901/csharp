//syntax: for(initializer; condition; iterator)
for (int i = 1; i < 10; i++) {
    for (int j = 1; j <= i; j++) {
        Console.Write($"{i} * {j} = " + i*j);
        if (j != 9) {
            Console.Write(", ");
        }
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("****************************");
Console.WriteLine();
//while loop

int num = 0;

bool condition = true;

while (condition) {
    num += 2;

    if (num == 6) { 
        condition = false;
    }
    Console.WriteLine($"num = {num}");
}
Console.WriteLine();
Console.WriteLine("****************************");
Console.WriteLine();
//do while

int attempts = 0;
bool success = false;

do {
    Console.WriteLine($"Enter password({3 - attempts} attempts):");
    string password = Console.ReadLine();
    if ("abc123".Equals(password)) {
        success = true;
    }
    attempts++;

} while (!success && attempts<3);

if (success)
{
    Console.WriteLine("welcome back!");
}
else {
    Console.WriteLine("Account is locked!!!");
}

Console.WriteLine();
Console.WriteLine("****************************");
Console.WriteLine();
//foreach loop
string[] courses = {"C#", "Web Dev", "Career Path", "SQL Server"};

foreach (string course in courses) {
    Console.WriteLine($"Course : {course}");
}