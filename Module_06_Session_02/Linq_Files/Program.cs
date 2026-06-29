using System.Collections.Generic;

namespace LinqPractice
{
    // Using a C# record for immutable data modeling
    public record CloudResource(string ResourceId, string Type, string Region, decimal MonthlyCost, bool IsActive);

    public class Program
    {
        public static void Main()
        {
            var resources = new List<CloudResource>
            {
                new("vm-alpha", "Compute", "us-east-1", 150.00m, true),
                new("db-beta", "Database", "us-east-1", 300.00m, true),
                new("vm-gamma", "Compute", "eu-west-1", 120.00m, true),
                new("vm-delta", "Compute", "us-east-1", 85.00m, true),
                new("vm-epsilon", "Compute", "us-east-1", 210.00m, false), // Inactive
                new("vm-zeta", "Compute", "us-east-1", 250.00m, true)
            };

            // TODO: Write your LINQ chain here
            // var expensiveUsEastComputeIds = ...
            var expensiveUsEastComputeIds = resources
                .Where(r => r.Type== "Compute" && r.Region == "us-east-1")
                .Where(r => r.IsActive == true)
                .Where(r => r.MonthlyCost > 100.00m)
                .OrderByDescending(r => r.MonthlyCost)
                .Select(r =>  r.ResourceId)
                .ToList();

            foreach (var resource in expensiveUsEastComputeIds)
            {
                Console.WriteLine(resource);
            }
            // Expected Output:
            // vm-zeta
            // vm-alpha
        }
    }
}