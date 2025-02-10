using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
    public List<string> Courses { get; set; }

    // Parameterless constructor
    public Student()
    {
        Name = "Unknown";
        Age = 18;
        Major = "Undeclared";
        Courses = new List<string>();
    }

    // Parameterized constructor
    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
        Courses = new List<string>();
    }

    // Method to display student details
    public void DisplayDetails()
    {
        Console.WriteLine($"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(Major)}: {Major}");
        DisplayCourses();
    }

    // Method to display courses
    public void DisplayCourses()
    {
        Console.WriteLine("Courses:");
        foreach (var course in Courses)
        {
            Console.WriteLine($"- {course}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Using parameterless constructor
        Student student1 = new Student();
        student1.DisplayDetails();

        // Using parameterized constructor
        Student student2 = new Student("Alice", 20, "Computer Science");
        student2.Courses.Add("ELO1000 - Succeeding Online");
        student2.Courses.Add("Passport to Canvas for Students");
        student2.Courses.Add("Live Online - College Algebra (AA) (2025 Spring 12 Weeks - MAC1105-26)");
        student2.Courses.Add("Online - C# Programming (AA) (2025 Spring Full Term - COP2360-4)");
        student2.Courses.Add("Online - Elements of Nutrition (AA) (2025 Spring 12 Weeks - HUN1201-8)");
        student2.DisplayDetails();

        // Using object initializer
        Student student3 = new Student { Name = "Bob", Age = 22, Major = "Mathematics" };
        student3.Courses.Add("ELO1000 - Succeeding Online");
        student3.Courses.Add("Passport to Canvas for Students");
        student3.Courses.Add("Live Online - College Algebra (AA) (2025 Spring 12 Weeks - MAC1105-26)");
        student3.Courses.Add("Online - C# Programming (AA) (2025 Spring Full Term - COP2360-4)");
        student3.Courses.Add("Online - Elements of Nutrition (AA) (2025 Spring 12 Weeks - HUN1201-8)");
        student3.DisplayDetails();
    }
}