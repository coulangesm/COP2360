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
            Console.WriteLine("\nWhat would you like to do?");
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

}