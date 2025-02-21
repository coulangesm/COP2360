class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nDivision Calculator");
            Console.WriteLine("------------------");
            
            // Get first number
            Console.Write("Enter the first number (or 'exit' to quit): ");
            string input1 = Console.ReadLine();
            
            // Check for exit condition
            if (input1.ToLower() == "exit")
                break;
            
            // Get second number
            Console.Write("Enter the second number: ");
            string input2 = Console.ReadLine();
            
            try
            {
                // Convert strings to integers
                int number1 = Convert.ToInt32(input1);
                int number2 = Convert.ToInt32(input2);
                
                // Perform division
                int result = Divide(number1, number2);
                
                // Display result
                Console.WriteLine($"\nResult: {number1} ÷ {number2} = {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nError: Please enter valid whole numbers only.");
                Console.WriteLine($"Technical details: {ex.Message}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nError: Cannot divide by zero.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("\nError: The number is too large or too small.");
                Console.WriteLine($"Technical details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn unexpected error occurred.");
                Console.WriteLine($"Technical details: {ex.Message}");
            }
            
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        
        Console.WriteLine("\nThank you for using the Division Calculator!");
    }
    
    static int Divide(int a, int b)
    {
        return a / b;
    }
}