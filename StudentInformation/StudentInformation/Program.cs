Console.WriteLine("----- Student Grade Average -----");

Console.WriteLine("Enter student name:");
string name = Console.ReadLine();

//get four score test
Console.WriteLine("Enter score 1(out of 100):");
//double score1 = double.Parse(Console.ReadLine());
bool check = double.TryParse(Console.ReadLine(), out double score1);
Console.WriteLine("check = "+check + ", score1 = " + score1);

Console.WriteLine("Enter score 2(out of 100):");
double score2 = double.Parse(Console.ReadLine());

Console.WriteLine("Enter score 3(out of 100):");
double score3 = double.Parse(Console.ReadLine());

Console.WriteLine("Enter score 4(out of 100):");
double score4 = double.Parse(Console.ReadLine());

//cauculate the average score using arithmetic operators
double avescore = (score1 + score2 + score3 + score4) / 4;
Console.WriteLine("Here is the average score: " + avescore);
