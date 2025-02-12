using System;

// Base class
public class Asset
{
    public string Name = "";

    // Describe a generic asset
    public virtual void Describe()
    {
        Console.WriteLine($"[Asset] Name: {Name}");
    }
}

// Derived class
public class Stock : Asset
{
    public long SharesOwned;

    // Overridden stock asset
    public override void Describe()
    {
        Console.WriteLine($"[Stock] Name: {Name}, Shares Owned: {SharesOwned}");
    }
}

// Derived class
public class House : Asset
{
    public decimal Mortgage;

    // Overridden house asset
    public override void Describe()
    {
        Console.WriteLine($"[House] Name: {Name}, Mortgage: {Mortgage}");
    }
}

public class Program
{
    public static void Main()
    {
        // Creating an instance of a generic asset
        Asset genericAsset = new Asset { Name = "Generic Asset" };

        // Creating an instance of a stock asset
        Stock apple = new Stock { Name = "Apple", SharesOwned = 1000 };

        // Creating an instance of a house asset
        House mansion = new House { Name = "Beverly Mansion", Mortgage = 500_000m };

        // Describing each asset
        genericAsset.Describe();
        apple.Describe();
        mansion.Describe();
    }
}
