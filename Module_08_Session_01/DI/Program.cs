using System;
using Microsoft.Extensions.DependencyInjection;

// ============================================================================
// 1. Setup Interfaces and Implementations
// ============================================================================
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG]: {message}");
}

public interface IOrderService
{
    void PlaceOrder(string itemName);
}

public class OrderService : IOrderService
{
    private readonly ILogger _logger;

    // The DI container automatically inspects this constructor and resolves ILogger
    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void PlaceOrder(string itemName)
    {
        _logger.Log($"Order placed successfully for: {itemName}");
    }
}

// ============================================================================
// 2. The Three DI Steps
// ============================================================================
internal class Program
{
    static void Main(string[] args)
    {
        // STEP 1: Register the mappings
        var services = new ServiceCollection();
        services.AddSingleton<ILogger, ConsoleLogger>();
        services.AddSingleton<IOrderService, OrderService>();

        // STEP 2: Build the provider (the container)
        var provider = services.BuildServiceProvider();

        // STEP 3: Resolve the service
        // The container constructs OrderService and automatically wires in ConsoleLogger
        var orderService = provider.GetRequiredService<IOrderService>();

        // Verify it works
        orderService.PlaceOrder("Custom Mechanical Keyboard");
    }
}