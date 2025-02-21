using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nDivision Calculator");
        Console.WriteLine("------------------");
        
        // Get first number
        Console.Write("Enter the first number: ");
        string input1 = Console.ReadLine();
        
        // Get second number
        Console.Write("Enter the second number: ");
        string input2 = Console.ReadLine();
        
        // Convert strings to integers directly without error handling
        int number1 = Convert.ToInt32(input1);
        int number2 = Convert.ToInt32(input2);
        
        // Perform division without error handling
        int result = Divide(number1, number2);
        
        // Display result
        Console.WriteLine($"\nResult: {number1} ÷ {number2} = {result}");
        
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
    
    static int Divide(int a, int b)
    {
        return a / b;
    }
}