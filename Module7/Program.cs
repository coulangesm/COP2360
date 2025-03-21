/*
* Movie Database Program
* Authors:
* - Michael Coulanges
* - Marcelo Alvarado
* - Ritdyaina Thelot
*
* This program allows users to manage a movie database, including adding, removing, and displaying movies and their actors.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dictionary to store movies and their associated actors
        Dictionary<string, List<string>> movieDatabase = new Dictionary<string, List<string>>();
        bool keepRunning = true;

        Console.WriteLine("++++ Welcome to the Movie Database ++++");

        // Main loop to keep the program running until the user chooses to exit
        while (keepRunning)
        {
            Console.WriteLine("\n++++ What would you like to do?");
            Console.WriteLine("1. Add sample movies to get started");
            Console.WriteLine("2. Show all movies in the database");
            Console.WriteLine("3. Remove a movie");
            Console.WriteLine("4. Add a new movie with actors");
            Console.WriteLine("5. Add an actor to an existing movie");
            Console.WriteLine("6. Show movies sorted alphabetically");
            Console.WriteLine("7. Exit");

            Console.Write("\nYour choice: ");
            string userChoice = Console.ReadLine();

            // Switch statement to handle user input
            switch (userChoice)
            {
                case "1":
                    AddSampleMovies(movieDatabase);
                    break;
                case "2":
                    ShowAllMovies(movieDatabase);
                    break;
                case "3":
                    RemoveMovie(movieDatabase);
                    break;
                case "4":
                    AddNewMovie(movieDatabase);
                    break;
                case "5":
                    AddActorToMovie(movieDatabase);
                    break;
                case "6":
                    ShowSortedMovies(movieDatabase);
                    break;
                case "7":
                    Console.WriteLine("Thank you for using the Movie Database. Goodbye!");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 7.");
                    break;
            }
        }
    }

    // Method to add movies to the database
    static void AddSampleMovies(Dictionary<string, List<string>> movies)
    {
        // Clear the existing database before adding sample movies
        movies.Clear();

        // Add movies with their actors
        movies["Spider-Man: No Way Home"] = new List<string> { "Tom Holland", "Zendaya." };
        movies["Top Gun: Maverick"] = new List<string> { "Tom Cruise", "Miles Teller", "Jennifer Connelly." };
        movies["Barbie"] = new List<string> { "Margot Robbie", "Ryan Gosling", "America Ferrera." };
        movies["Oppenheimer"] = new List<string> { "Cillian Murphy", "Emily Blunt", "Robert Downey Jr." };

        Console.WriteLine("Movies added successfully.");
    }

    // Method to display all movies and their actors in the database
    static void ShowAllMovies(Dictionary<string, List<string>> movies)
    {
        if (movies.Count == 0)
        {
            Console.WriteLine("The database is empty. Add some movies first.");
            return;
        }

        Console.WriteLine("\n++++ MOVIE DATABASE ++++");
        foreach (var movie in movies)
        {
            Console.WriteLine($"\nMovie: {movie.Key}");
            Console.Write("Starring: ");
            Console.WriteLine(string.Join(", ", movie.Value));
        }
    }

    // Method to remove a movie from the database
    static void RemoveMovie(Dictionary<string, List<string>> movies)
    {
        if (movies.Count == 0)
        {
            Console.WriteLine("No movies available to remove.");
            return;
        }

        // Display available movies for removal
        Console.WriteLine("Available movies:");
        int index = 1;
        foreach (string title in movies.Keys)
        {
            Console.WriteLine($"{index}. {title}");
            index++;
        }

        Console.Write("\nEnter the name of the movie to remove: ");
        string movieToRemove = Console.ReadLine();

        // Check if the movie exists and remove it
        if (movies.ContainsKey(movieToRemove))
        {
            movies.Remove(movieToRemove);
            Console.WriteLine($"'{movieToRemove}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Movie '{movieToRemove}' not found.");
        }
    }

    // Method to add a new movie with its actors to the database
    static void AddNewMovie(Dictionary<string, List<string>> movies)
    {
        Console.Write("Enter the name of the movie: ");
        string newMovie = Console.ReadLine();

        // Check if the movie already exists
        if (movies.ContainsKey(newMovie))
        {
            Console.WriteLine($"'{newMovie}' already exists in the database.");
            return;
        }

        Console.Write("Enter the actors (separated by commas): ");
        string actorsInput = Console.ReadLine();
        List<string> actorsList = new List<string>();

        // Split the input string into individual actors and add them to the list
        foreach (string actor in actorsInput.Split(','))
        {
            string trimmedActor = actor.Trim();
            if (!string.IsNullOrEmpty(trimmedActor))
            {
                actorsList.Add(trimmedActor);
            }
        }

        // Add the new movie and its actors to the database
        movies[newMovie] = actorsList;
        Console.WriteLine($"'{newMovie}' added with {actorsList.Count} actors.");
    }

    // Method to add an actor to an existing movie
    static void AddActorToMovie(Dictionary<string, List<string>> movies)
    {
        if (movies.Count == 0)
        {
            Console.WriteLine("No movies available. Add some first.");
            return;
        }

        // Display available movies
        Console.WriteLine("Available movies:");
        int index = 1;
        foreach (string title in movies.Keys)
        {
            Console.WriteLine($"{index}. {title}");
            index++;
        }

        Console.Write("\nEnter the name of the movie: ");
        string movieToUpdate = Console.ReadLine();

        // Check if the movie exists
        if (!movies.ContainsKey(movieToUpdate))
        {
            Console.WriteLine($"Movie '{movieToUpdate}' not found.");
            return;
        }

        // Display current actors in the movie
        Console.WriteLine($"\nCurrent actors in '{movieToUpdate}':");
        Console.WriteLine(string.Join(", ", movies[movieToUpdate]));

        Console.Write("\nEnter the name of the actor to add: ");
        string newActor = Console.ReadLine().Trim();

        // Check if the actor is already listed
        if (movies[movieToUpdate].Contains(newActor))
        {
            Console.WriteLine($"'{newActor}' is already listed.");
            return;
        }

        // Add the new actor to the movie
        movies[movieToUpdate].Add(newActor);
        Console.WriteLine($"'{newActor}' added to '{movieToUpdate}'.");
    }

    // Method to display all movies sorted alphabetically
    static void ShowSortedMovies(Dictionary<string, List<string>> movies)
    {
        if (movies.Count == 0)
        {
            Console.WriteLine("No movies available to sort.");
            return;
        }

        Console.WriteLine("\n++++ Movies sorted ++++");
        List<string> sortedTitles = new List<string>(movies.Keys);
        // Sort the movie titles alphabetically
        sortedTitles.Sort(); 

        // Display sorted movies and their actors
        foreach (string title in sortedTitles)
        {
            Console.WriteLine($"\nMovie: {title}");
            Console.Write("Starring: ");
            Console.WriteLine(string.Join(", ", movies[title]));
        }
    }
}