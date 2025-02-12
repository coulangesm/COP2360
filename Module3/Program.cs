using System;

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

    // Display student details
    public void DisplayDetails()
    {
        Console.WriteLine($"\n{nameof(Name)}: {Name}");
        Console.WriteLine($"{nameof(Age)}: {Age}");
        Console.WriteLine($"{nameof(Major)}: {Major}");
        DisplayCourses();
    }

    // Display courses
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
        // Using parameterized constructor
        Student student1 = new Student("Thomas", 22, "Computer Science");
        student1.Courses.Add("Introduction to Programming");
        student1.Courses.Add("Data Structures and Algorithms");
        student1.Courses.Add("Database Systems");
        student1.DisplayDetails();

        // Using object initializer
        Student student2 = new Student { Name = "Mabel", Age = 20, Major = "Mathematics" };
        student2.Courses.Add("Calculus I");
        student2.Courses.Add("Linear Algebra");
        student2.Courses.Add("Probability and Statistics");
        student2.DisplayDetails();
    }
}