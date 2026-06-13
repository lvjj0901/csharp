// Student name: Junjie(Jason) Lyu  Student ID: N01793658

Console.WriteLine("*********Welcome to Humber Campus Cafe*********");
string[] items = { "Americano", "Latte", "Cappuccino", "Mocha", "Brownie", "Cookie", "Oat Bar", "Muffin"};
double[] prices = {4.55, 4.95, 4.55, 5.95, 3.95, 3.45, 3.45, 3.65 };
int[] order = new int[8];
const double HST = 0.13;

string menu = """

        ========== Humber Campus Cafe Menu ==========

                ItemNO.  ItemName     ItemPrice
        Drinks:         
                   1     Americano    $4.55
                  -----------------------------
                   2     Latte        $4.95
                  -----------------------------
                   3     Cappuccino   $4.55
                  -----------------------------
                   4     Mocha        $5.95
        Treats:         
                        
                   5     Brownie      $3.95
                  -----------------------------
                   6     Cookie       $3.45
                  -----------------------------
                   7     Oat Bar      $3.45
                  -----------------------------
                   8     Muffin       $3.65
                  -----------------------------
 
        """;
Console.WriteLine(menu);

string close = """

               ---------------------------
                Thank you for shopping at
                   Humber Campus Cafe
               ---------------------------
               """;


Console.WriteLine("""
                    -------------------------------
                       Enter ItemNO.(1-8) to add item
                    or Enter 1000  to Exit
                    or Enter   0   to checkout: 
                    """);
bool checkOut = false;
do
{
    int itemNO = 0;
    string input = Console.ReadLine();
    bool checkItemNO = int.TryParse(input, out itemNO);
    while (!checkItemNO)
    {
        Console.WriteLine("""
                        !-----------------------------!
                           Enter a valid ItemNO.(1-8)
                        or Enter 1000  to Exit
                        or Enter   0   to checkout: 
                        """);
        input = Console.ReadLine();
        checkItemNO = int.TryParse(input, out itemNO);
    }

    if (itemNO == 1000)
    {
        Console.WriteLine(close);
        Environment.Exit(0);
    }
    else if (itemNO == 0) 
    {
        checkOut = true;
    }
    else if (itemNO > 0 && itemNO < 9)
    {
        Console.WriteLine("""
                            *-----------------------------*
                               Enter Item quantity(1–10)
                            or Enter 1000  to Exit
                            or Enter   0   to checkout: 
                            """);
        bool checkQuantity = false;
        int itemQuantity = 0;
        do
        {
            input = Console.ReadLine();
            bool checkQuantityNO = int.TryParse(input, out itemQuantity);
            while (!checkQuantityNO)
            {
                Console.WriteLine("""
                                !*---------------------------*!
                                   Enter a valid Item quantity(1–10)
                                or Enter 1000  to Exit
                                or Enter   0   to checkout: 
                                """);
                input = Console.ReadLine();
                checkQuantityNO = int.TryParse(input, out itemQuantity);
            }

            if (itemQuantity == 1000)
            {
                Console.WriteLine(close);
                Environment.Exit(0);
            }
            else if (itemQuantity == 0)
            {
                checkOut = true;
                checkQuantity = true;
            }
            else if (itemQuantity > 0 && itemQuantity < 11)
            {
                checkQuantity = true;
                order[itemNO - 1] = itemQuantity;
                checkOut = false;
                Console.WriteLine("""
                    -------------------------------
                       Enter ItemNO.(1-8) to add item
                    or Enter 1000  to Exit
                    or Enter   0   to checkout: 
                    """);
            }
            else
            {
                checkQuantity = false;
                Console.WriteLine("""
                                !*---------------------------*!
                                   Enter a valid Item quantity(1–10)
                                or Enter 1000  to Exit
                                or Enter   0   to checkout: 
                                """);
            }

        } while (!checkQuantity);

    }
    else
    {
        checkOut = false;
        Console.WriteLine("""
                        !-----------------------------!
                           Enter a valid ItemNO.(1-8)
                        or Enter 1000  to Exit
                        or Enter   0   to checkout: 
                        """);
    }

} while (!checkOut);

string receiptHead = """

                                        Humber Campus Cafe
                     ---------------------------------------------------------
                     ItemNO.  ItemName     ItemPrice     Quantity             
                     """;
Console.WriteLine(receiptHead);
double subTotal = 0.0;
double grandTotal = 0.0;
for (int i = 0; i < order.Length; i++)
{
    int quantity = order[i];
    if (quantity != 0)
    {
        double itemPrice = prices[i];
        double amount = itemPrice * quantity;
        subTotal += amount;
        Console.WriteLine($"    {i+1}   {items[i],10}     {itemPrice:C2}           {quantity,2}         {amount:C2}");
    }
}

string receiptTail = "";
if (subTotal == 0.0)
{
    Console.WriteLine($"   -        -            -             -      0.00");
    Console.WriteLine(close);
    Environment.Exit(0);
}
else if (subTotal > 25.0)
{
    grandTotal = subTotal * 0.9 * (1 + HST);
    receiptTail = $"""
                     ---------------------------------------------------------
                                                         Subtotal      {subTotal:C2}
                                                         10% discount  -{subTotal * 0.1:C2}
                                                         HST 13%       {subTotal * 0.9 * HST:C2}
                                                         Grand total   {grandTotal:C2}
                     {DateTime.Now}
                     ---------------------------------------------------------

                     """;

}
else 
{
    grandTotal = subTotal * (1 + HST);
    receiptTail = $"""
                     ---------------------------------------------------------
                                                         Subtotal     {subTotal:C2}
                                                         HST 13%      {subTotal * HST:C2}
                                                         Grand total  {grandTotal:C2}

                     {DateTime.Now}
                     ---------------------------------------------------------

                     """;
};
Console.WriteLine(receiptTail);
Console.WriteLine("How much cash you are paying:");
bool checkChange = true;
do 
{
    double cashAmount = 0.0;
    string payment = Console.ReadLine();
    bool checkcashAmounth = double.TryParse(payment, out cashAmount);
    while (!checkcashAmounth)
    {
        Console.Write("Enter a valid cash amount:");
        payment = Console.ReadLine();
        checkcashAmounth = double.TryParse(payment, out cashAmount);
    }

    if (cashAmount > grandTotal)
    {
        double change = cashAmount - grandTotal;
        checkChange = true;
        Console.WriteLine();
        Console.WriteLine($"Your change is: {cashAmount - grandTotal:C2}");
    }
    else 
    {
        Console.Write("Enter a valid cash amount:");
        checkChange = false;
    }
} while (!checkChange);


Console.WriteLine(close);