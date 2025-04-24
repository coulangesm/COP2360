using System;
using System.Globalization;

// This class represents a subcontractor, inheriting from the Contractor class.
public class Subcontractor : Contractor
{
    // Constants for shift types
    public const int DAY_SHIFT = 1;
    public const int NIGHT_SHIFT = 2;

    // Constants for pay rate differentials
    private const float NIGHT_SHIFT_DIFFERENTIAL_RATE = 0.03f;

    // Private fields for shift and hourly pay rate
    private int _shift;
    private double _hourlyPayRate;

    // Default constructor
    public Subcontractor() : base()
    {
        _shift = DAY_SHIFT;
        _hourlyPayRate = 0.0;
    }

    // Parameterized constructor
    public Subcontractor(string name, string number, DateTime startDate, int shift, double hourlyRate)
        : base(name, number, startDate)
    {
        Shift = shift;
        HourlyPayRate = hourlyRate;
    }

    // Properties for shift and hourly pay rate
    public int Shift
    {
        get { return _shift; }
        set
        {
            if (value == DAY_SHIFT || value == NIGHT_SHIFT)
            {
                _shift = value;
            }
            else
            {
                Console.WriteLine($"Warning: Invalid shift value ({value}). Setting to Day Shift (1).");
                _shift = DAY_SHIFT;
            }
        }
    }

    // Property for hourly pay rate with validation
    public double HourlyPayRate
    {
        get { return _hourlyPayRate; }
        set
        {
            if (value >= 0)
            {
                _hourlyPayRate = value;
            }
            else
            {
                Console.WriteLine($"Warning: Invalid hourly rate ({value}). Setting to 0.0.");
                _hourlyPayRate = 0.0;
            }
        }
    }

    // Method to calculate pay based on hours worked and shift type
    public float CalculatePay(double hoursWorked)
    {
        if (hoursWorked < 0)
        {
             Console.WriteLine("Warning: Hours worked cannot be negative. Calculating pay for 0 hours.");
             hoursWorked = 0;
        }

        double basePay = hoursWorked * HourlyPayRate;
        double totalPay = basePay;

        if (Shift == NIGHT_SHIFT)
        {
            double differentialAmount = basePay * NIGHT_SHIFT_DIFFERENTIAL_RATE;
            totalPay += differentialAmount;
        }

        return (float)totalPay;
    }

    // Method to display subcontractor information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"  Shift: {(Shift == DAY_SHIFT ? "Day (1)" : "Night (2)")}");
        Console.WriteLine($"  Hourly Rate: {HourlyPayRate.ToString("C", CultureInfo.CurrentCulture)}");
    }
}