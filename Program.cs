using System;

namespace TicketBooking
{
    internal class Program
    {
        static string[] movies = { "Avengers: Endgame", "Inception", "Interstellar", "Joker" };
        static int[] availableTickets = { 55, 40, 30, 20 };
        static string[] actions = { "[1] View Available Tickets", "[2] Book a Ticket", "[3] Cancel a Ticket", "[4] Select Another Movie", "[5] Exit" };

        static void Main(string[] args)
        {
            Console.WriteLine("MOVIE TICKET BOOKING SYSTEM");

            int movieChoice;

            do
            {
                movieChoice = SelectMovie();

                if (movieChoice == -1)
                    break;

                int userAction;
                do
                {
                    DisplayActions();
                    userAction = GetUserInput();
                    HandleMovieAction(userAction, movieChoice);

                } while (userAction != 4 && userAction != 5);

            } while (movieChoice != -1);

            Console.WriteLine("Exiting program...");
        }

        static void DisplayMovies()
        {
            Console.WriteLine("\nAvailable Movies:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {movies[i]} - Available Tickets: {availableTickets[i]}");
            }
        }

        static int SelectMovie()
        {
            int choice;
            do
            {
                DisplayMovies();
                Console.Write("Select a Movie: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 0) return -1;
                    if (choice >= 1 && choice <= movies.Length) return choice - 1;
                }

                Console.WriteLine("Invalid selection. Please try again.");

            } while (true);
        }

        static void DisplayActions()
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("\nACTIONS:");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("Select Action: ");
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 5)
            {
                return input;
            }

            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            return GetUserInput();
        }

        static void HandleMovieAction(int action, int movieChoice)
        {
            switch (action)
            {
                case 1:
                    DisplayAvailableTickets(movieChoice);
                    break;
                case 2:
                    BookTicket(movieChoice);
                    break;
                case 3:
                    CancelTicket(movieChoice);
                    break;
                case 4:
                    Console.WriteLine("Returning to movie selection...");
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
            }
        }

        static void DisplayAvailableTickets(int movieChoice)
        {
            Console.WriteLine($"Available tickets for {movies[movieChoice]}: {availableTickets[movieChoice]}");
        }

        static void UpdateTickets(int action, int movieChoice, int amount)
        {
            if (action == 2) 
            {
                if (availableTickets[movieChoice] >= amount)
                {
                    availableTickets[movieChoice] -= amount;
                    Console.WriteLine("Ticket booked successfully.");
                }
                else
                {
                    Console.WriteLine("No tickets available.");
                }
            }
            else if (action == 3) 
            {
                availableTickets[movieChoice] += amount;
                Console.WriteLine("Ticket canceled successfully.");
            }

            DisplayAvailableTickets(movieChoice);
        }

        static void BookTicket(int movieChoice)
        {
            Console.Write("Enter number of tickets to book: ");
            if (int.TryParse(Console.ReadLine(), out int numTickets) && numTickets > 0)
            {
                UpdateTickets(2, movieChoice, numTickets);
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a valid amount.");
            }
        }

        static void CancelTicket(int movieChoice)
        {
            Console.Write("Enter number of tickets to cancel: ");
            if (int.TryParse(Console.ReadLine(), out int numTickets) && numTickets > 0)
            {
                UpdateTickets(3, movieChoice, numTickets);
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a valid amount.");
            }
        }
    }
}