using System;
using System.Collections.Generic;
using System.Globalization;

// This program is a simple console application that manages subcontractor information and
// calculates their pay based on hours worked.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Subcontractor Management ---");

        // Create a list to store subcontractors
        List<Subcontractor> subcontractors = new List<Subcontractor>();

        bool addMore = true;

        // Loop to add subcontractors until the user decides to stop
        while (addMore)
        {
            Console.WriteLine("\nEnter details for a new subcontractor:");

            string name = GetStringInput("Enter Contractor Name: ");
            string number = GetStringInput("Enter Contractor Number: ");
            DateTime startDate = GetDateInput("Enter Start Date (YYYY-MM-DD): ");
            int shift = GetShiftInput("Enter Shift (1 for Day, 2 for Night): ");
            double hourlyRate = GetDoubleInput("Enter Hourly Pay Rate: ");

            // Create a new Subcontractor object and add it to the list
            try
            {
                Subcontractor newSub = new Subcontractor(name, number, startDate, shift, hourlyRate);
                subcontractors.Add(newSub);
                Console.WriteLine("Subcontractor added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating subcontractor: {ex.Message}");
            }

            // Ask if the user wants to add another subcontractor
            Console.Write("\nAdd another subcontractor? (y/n): ");
            string response = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            addMore = (response == "y" || response == "yes");
            Console.WriteLine();
        }

        Console.WriteLine("\n--- Subcontractor Summary ---");
        if (subcontractors.Count == 0)
        {
            Console.WriteLine("No subcontractors were entered.");
        }
        else
        {
            // Display the details of each subcontractor
            foreach (var sub in subcontractors)
            {
                Console.WriteLine("-----------------------------------");
                sub.DisplayInfo();

                double hoursWorked = GetDoubleInput($"\nEnter hours worked for {sub.Name}: ");

                float totalPay = sub.CalculatePay(hoursWorked);
                Console.WriteLine($"  Calculated Pay: {totalPay.ToString("C", CultureInfo.CurrentCulture)}");
                Console.WriteLine("-----------------------------------");
            }
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    // Helper methods to get user input
    static string GetStringInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    // Method to get a date input from the user
    static DateTime GetDateInput(string prompt)
    {
        DateTime dateValue;
        string input;
        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine() ?? string.Empty;
            if (DateTime.TryParse(input, out dateValue))
            {
                return dateValue;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD or another valid format.");
            }
        }
    }

    // Method to get a shift input from the user
    static int GetShiftInput(string prompt)
    {
        int shiftValue;
        string input;
        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine() ?? string.Empty;
            if (
                int.TryParse(input, out shiftValue) &&
                (shiftValue == Subcontractor.DAY_SHIFT ||
                shiftValue == Subcontractor.NIGHT_SHIFT)
                )
            {
                return shiftValue;
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter {Subcontractor.DAY_SHIFT} for Day or {Subcontractor.NIGHT_SHIFT} for Night.");
            }
        }
    }

    // Method to get a double input from the user
    static double GetDoubleInput(string prompt)
    {
        double value;
        string input;

        Console.Write(prompt);
        input = Console.ReadLine() ?? string.Empty;

        while (!double.TryParse(input, out value) || value < 0)
        {
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
            Console.Write(prompt);
            input = Console.ReadLine() ?? string.Empty;
        }

        return value;
    }
}