using System;

// Design of the Contractor class
public class Contractor
{
    // Private fields for the Contractor class
    private string _name;
    private string _number;
    private DateTime _startDate;

    // Default constructor
    public Contractor()
    {
        _name = "Unknown";
        _number = "00000";
        _startDate = DateTime.MinValue;
    }

    // Parameterized constructor
    public Contractor(string name, string number, DateTime startDate)
    {
        _name = "Unnamed";
        _number = "00000";
        Name = name;
        Number = number;
        StartDate = startDate;
    }

    // Properties for the Contractor class
    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _name = value;
            }
            else
            {
                Console.WriteLine("Warning: Contractor name cannot be empty.");
                _name = "Unnamed";
            }
        }
    }

    // Property for the contractor number with validation
    public string Number
    {
        get { return _number; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _number = value;
            }
            else
            {
                Console.WriteLine("Warning: Contractor number cannot be empty.");
                _number = "00000";
            }
        }
    }

    // Property for the start date with validation
    public DateTime StartDate
    {
        get { return _startDate; }
        set
        {
            _startDate = value;
        }
    }

    // Method to display contractor information
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name}");
        Console.WriteLine($"  Number: {Number}");
        Console.WriteLine($"  Start Date: {StartDate.ToShortDateString()}");
    }
}