using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
    }
}


public class Invoice
{
    public decimal Subtotal { get; set; }
    public decimal CalculateTax() => Subtotal * 0.13m;
    public decimal CalculateTotal() => Subtotal + CalculateTax();
}

public class InvoiceFileWriter
{
    public void SaveToFile(string path) => File.WriteAllText(path, "this is my text");
}

public class InvoiceEmailer
{
    public void SendEmail(string to) { /* SMTP code here */ }
}

public class  InvoiceHtmlFormatter
{
    public string FormatHtml() => $"<h1>Invoice</h1>...";
}