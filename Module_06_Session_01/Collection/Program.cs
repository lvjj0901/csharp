List<string> tasks = new List<string>();

Console.WriteLine("----------TO-DO List manager-----------");
Console.WriteLine();
Console.WriteLine("choose an option(1-4):");
Console.WriteLine("1.Add task 2.Remove task 3.List tasks 4.Quit");
Console.Write(">");
string input = Console.ReadLine();
do
{
    switch (input)
    {
        case "1":
            Console.Write("Enter a task to add: ");
            string taskToAdd = Console.ReadLine();
            tasks.Add(taskToAdd);
            break;
        case "2":
            Console.Write("Enter a task index to remove: ");
            string taskToRemove = Console.ReadLine();
            if (int.TryParse(taskToRemove, out int index))
            {
                if (index >= 0 && index < tasks.Count)
                {
                    tasks.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid task index.");
                }
            } else
            {
                Console.WriteLine("Task not found.");
            }
            break;
        case "3":
            Console.WriteLine("TO-DO List:");
            int size = tasks.Count;
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i}--> {tasks[i]}");
            }
            break;
        case "4":
            Console.WriteLine("Exiting the program.");
            break;
        default:
            Console.WriteLine("Invalid option. Please choose again.");
            break;
    }
    if (input != "4")
    {
        Console.WriteLine();
        Console.WriteLine("choose an option(1-4):");
        Console.Write(">");
        input = Console.ReadLine();
    }
} while (input != "4");

//int[] ints1 = new int[4];
//int[] ints2 = new int[] {1,2,3,4,5};
//int[] ints3 = { 1, 2, 3, 4, 5 };

//string[] students = new string[3] { "Alice", "Bob", "Charlie" };

////foreach (string s in students[..^1])
////{ 
////    Console.WriteLine(s);
////}

//var names = new List<string> { "Alice", "Bob", "Bob", "Charlie" };
//foreach (string s in names)
//{
//    Console.WriteLine(s);
//}
//List<string>.Enumerator enumerator1 = names.GetEnumerator();

//IEnumerable<string> enumerator2 = new List<string> { "Alice", "Bob", "Bob", "Charlie" };
//Console.WriteLine("-------------------");
//names.Remove("Bob");
//foreach (string s in names)
//{
//    Console.WriteLine(s);
//}

//Dictionary<string, int> dic = new Dictionary<string, int>();
//Dictionary<string, int>.Enumerator enumerator = dic.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    Console.WriteLine($"{enumerator.Current.Key}: {enumerator.Current.Value}");
//}