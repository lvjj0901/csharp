const decimal HST = 0.13m;
var quantity = 0;
var unitPrice = 0.0m;

Console.WriteLine("Enter the customer's name:");
string customer = Console.ReadLine();

Console.WriteLine("Enter quantity:");
quantity = int.Parse(Console.ReadLine());

Console.WriteLine("Enter unitPrice:");
unitPrice = decimal.Parse(Console.ReadLine());

var subTotal = unitPrice * quantity;
var tax = subTotal * HST;
var total = subTotal + tax;

var invoceHead = """
    =======================
             Invoice 
    =======================
    Customer name:
    """;
//Console.WriteLine("=======================");
//Console.WriteLine("Invoice");
Console.Write(invoceHead);
Console.Write(customer);
Console.WriteLine("");
Console.WriteLine("quantity = " + quantity);
Console.WriteLine("unitPrice = " + unitPrice);
Console.WriteLine($"subTotal is :{subTotal:c2}");
Console.WriteLine($"tax is :{tax:c3}");
Console.WriteLine($"total is :{total:c2}");