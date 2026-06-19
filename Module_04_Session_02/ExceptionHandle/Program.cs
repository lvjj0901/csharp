

using System.Security.Cryptography.X509Certificates;

class ExceptionExample 
{
    public static void Main(string[] args)
    {
        try
        {
            int result = Divide();
            Console.WriteLine($"Here is the result:{result}");
        }
        catch (DivideByZeroException ex) 
        {
            Console.WriteLine($"You cannot divide by zero:{ex.Message}");
        }
        finally
        { 
            Console.WriteLine("This will always execute");
        }
    }

    public static int Divide()
    {
        Console.WriteLine("PLS enter a divisor");
        int divisor = int.Parse(Console.ReadLine());
        int dividen = 100;
        int result = dividen / divisor;
        return result;
    }

    public int ParsePositiveInt(string input)
    {
        try 
        {
            var n = int.Parse(input);
            if (n < 0)
            { 
                throw new ArgumentOutOfRangeException(nameof(input), "Input must be a positive integer.");
            }
            return n;
        }
        catch (FormatException ex)
        {
            return -1; // Indicate invalid format
        }
        catch (ArgumentOutOfRangeException ex)

        {
            return -2; // Indicate out of range
        }
    }
}
