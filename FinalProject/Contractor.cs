using System;


public class Contractor
{
    private string _name;
    private string _number;
    private DateTime _startDate;

    public Contractor()
    {
        _name = "Unknown";
        _number = "00000";
        _startDate = DateTime.MinValue;
    }

    public Contractor(string name, string number, DateTime startDate)
    {
        _name = "Unnamed";
        _number = "00000";
        Name = name;
        Number = number;
        StartDate = startDate;
    }

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

    public DateTime StartDate
    {
        get { return _startDate; }
        set
        {
            _startDate = value;
        }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name}");
        Console.WriteLine($"  Number: {Number}");
        Console.WriteLine($"  Start Date: {StartDate.ToShortDateString()}");
    }
}