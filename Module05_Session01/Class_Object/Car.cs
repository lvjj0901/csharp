Car honda = new Car("Honda", "Civic");

honda.Make = "Toyota";
Console.WriteLine(honda.Make); // Output: Toyota

public class Car(string make, string model)
{ 
    public string Make { get; set; } = make ?? throw new ArgumentNullException(nameof(make));
    public string Model { get; set; } = model ?? throw new ArgumentNullException(nameof(model));
}
