
//int result = Calculator.Add(5, 10);
//public class Calculator
//{
//    public static int Add(int a, int b) 
//    {
//        return a + b;
//    }
//}

//pass value
//public class Example
//{
//    public static void Main(string[] args)
//    {
//        int number = 10;
//        ModifyValue(number);
//        Console.WriteLine(number); // Output will still be 10, not 50

//    }

//    private static void ModifyValue(int value)
//    {
//        value = 50; // This modification will not affect the original variable
//    }
//}

//pass reference
//public class Example
//{
//    public static void Main(string[] args)
//    {
//        int number = 10;
//        ModifyValue(ref number);
//        Console.WriteLine(number); // Output will still be 10, not 50

//    }

//    private static void ModifyValue(ref int value)
//    {
//        value = 50; // This modification will not affect the original variable
//    }
//}

//out keyword
//public class OutExample
//{ 
//    public static void Main(string[] args)
//    { 
//        double a = 10;
//        double b = 0;
//        if (TryDivide(a, b, out double result))
//        {
//            Console.WriteLine($"Result: {result}");
//        }
//        else
//        {
//            Console.WriteLine("Cannot divide by zero.");
//        }

//    }
//    private static bool TryDivide(double a, double b, out double result)
//    {
//        if (b == 0)
//        {
//            result = 0;
//            return false;
//        }
//        else 
//        {
//            result = a / b;
//            return true;
//        }
//    }
//}


//params keyword
public class ParamsExample
{
    public static void Main(string[] args)
    {
        printNumbers(1,2,3);
        printNumbers(1);
    }

    private static void printNumbers(params int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

    }
}

//return value and tuple
public class TupleExample 
{
    //single return value
    decimal Tax(decimal x) => x * 0.15m;
    //void - does something, returns nothing
    void print(string msg) => Console.WriteLine(msg);

    //tuple for muitiple returns
    (string name, int age) ParseRecord(string line)
    { 
        var parts = line.Split(',');
        return (parts[0], int.Parse(parts[1]));
    }

    //var (name,age) = ParseRecord("Alice,30");
}

//method overloading

public class OverloadingExample
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Add(5, 10)); // Calls the method with two int parameters
        Console.WriteLine(Add(5.5, 10.5)); // Calls the method with two double parameters
        Console.WriteLine(Add(5, 10, 15)); // Calls the method with three int parameters
    }
    private static int Add(int a, int b)
    {
        return a + b;
    }
    private static double Add(double a, double b)
    {
        return a + b;
    }
    private static int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}