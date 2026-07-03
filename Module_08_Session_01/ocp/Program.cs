using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
    }
}

//public class DiscountService
//{
//    public decimal Discount(string customerType) => customerType switch
//    {
//        "Regular" => 0m,
//        "Premium" => 0.1m,
//        "Vip" => 0.2m,
//        _ => 0m
//    };
//}

public interface IDiscountStrategy
{
    decimal Calculate(decimal amount);
}

public class RegularDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount) => 0m;
}

public class PremiumDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount) => 0.1m;
}

public class VIPDiscount :IDiscountStrategy
{
    public decimal Calculate(decimal amount) => 0.2m;
}

public class OtherDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount) => 0m;
}

public class DiscountService
{
    private IDiscountStrategy _strategy;

    public DiscountService(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateDiscount(decimal amount)
    {
        return _strategy.Calculate(amount);
    }
}