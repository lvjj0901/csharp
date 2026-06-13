//Student name: Junjie(Jason) Lyu  Student ID: N01793658

Console.WriteLine("Enter the student's full name:");
string name = Console.ReadLine();

Console.WriteLine("Enter the student ID:");
string id = Console.ReadLine();
int mark = 0;
int highestMark = -1;
int lowestMark = 101;

string[] subjects = { "Mathematics", "English", "Science", "History", "Computer Science", "","" };

int total = 0;

for(int i = 0; i < subjects.Length - 2 ; i++)
{
    Console.WriteLine($"Enter {subjects[i]}'s mark(0–100) :");
    string tmp = Console.ReadLine();
    bool checkMark = int.TryParse(tmp, out mark);

    while (!checkMark) 
    {
        Console.WriteLine($"Enter a valid {subjects[i]}'s mark(0–100) :");
        tmp = Console.ReadLine();
        checkMark = int.TryParse(tmp, out mark);
    }
   
    if (highestMark < mark)
    {
        highestMark = mark;
        subjects[subjects.Length - 2] = highestMark + "  (" + subjects[i] + ")";
    }

    if (lowestMark > mark)
    {
        lowestMark = mark;
        subjects[subjects.Length - 1] = lowestMark + "  (" + subjects[i] + ")";
    }

    //subjects[i] = " "+subjects[i] + "          " + mark;
    subjects[i] = mark + "";
    total += mark;
}

double average = total / 5.0;
//Assign a letter grade based on the average: A (90+), B (80–89), C (70–79), D (60–69), F (below 60)
char grade = average switch
{
    >= 90 => 'A',
    >= 80 => 'B',
    >= 70 => 'C',
    >= 60 => 'D',
    _ => 'F'
};
string status = average >= 60 ? "PASS" : "FAIL";
string display = $"""
                    ========================================
                             HUMBER POLYTECHNIC
                               REPORT CARD
                    ========================================
                    Student:    {name}
                    Student ID: {id}
                    ----------------------------------------
                    Subject             Mark
                    ----------------------------------------
                    Mathematics         {subjects[0]}
                    English             {subjects[1]}
                    Science             {subjects[2]}
                    History             {subjects[3]}
                    Computer Science    {subjects[4]}                
                    ----------------------------------------
                   """;
Console.WriteLine(display);
//for (int i = 0; i < subjects.Length - 2; i++)
//{
//    Console.WriteLine(subjects[i]);
//}

string summary = $"""
                   Total:               {total} / 500
                   Average:             {average:F2} %
                   Highest:             {subjects[subjects.Length - 2]}
                   Lowest:              {subjects[subjects.Length - 1]}
                   Letter Grade:        {grade}
                   Status:              {status}
                   ========================================
                  """;
Console.WriteLine(summary);