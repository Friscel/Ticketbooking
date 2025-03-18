using System;

namespace TicketBooking
{
    internal class Program
    {
        static string[] movies = { "Avengers: Endgame", "Inception", "Interstellar", "Joker" };
        static int[] availableTickets = { 55, 40, 30, 20 };

        static void Main(string[] args)
        {
            Console.WriteLine("MOVIE TICKET BOOKING SYSTEM");

            while (true)
            {
                int movieChoice;
                do
                {
                    movieChoice = SelectMovie();
                    if (movieChoice == -2)
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                    }
                } while (movieChoice == -2);

                if (movieChoice == -1) 
                    break;

                int userAction;
                do
                {
                    DisplayActions();
                    userAction = GetUserInput();
                    HandleAction(userAction, movieChoice);
                } 
                while (userAction != 4 && userAction != 5);
            }
            Console.WriteLine("Exiting program...");
        }

        static int SelectMovie()
        {
            Console.WriteLine("\nAvailable Movies:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {movies[i]} - Available Tickets: {availableTickets[i]}");
            }
            Console.Write("Select a Movie: ");
            int choice = Convert.ToInt32(Console.ReadLine()) -1 ;

            return (choice >= -1 && choice < movies.Length) ? choice : -2;
        }

        static void DisplayActions()
        {
            string[] actions = { "[1] View Available Tickets", "[2] Book a Ticket", "[3] Cancel a Ticket", "[4] Select Another Movie", "[5] Exit" };
            Console.WriteLine("\nACTIONS");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("Enter Action: ");
            return Convert.ToInt16(Console.ReadLine());
        }

        static void HandleAction(int action, int movieChoice)
        {
            switch (action)
            {
                case 1:
                    Console.WriteLine($"Available tickets for {movies[movieChoice]}: {availableTickets[movieChoice]}");
                    break;
                case 2:
                    if (availableTickets[movieChoice] > 0)
                    {
                        availableTickets[movieChoice]--;
                        Console.WriteLine("Ticket booked successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No tickets available.");
                    }
                    Console.WriteLine($"Remaining tickets for {movies[movieChoice]}: {availableTickets[movieChoice]}");
                    break;
                case 3:
                    availableTickets[movieChoice]++;
                    Console.WriteLine("Ticket canceled successfully.");
                    Console.WriteLine($"Available tickets for {movies[movieChoice]}: {availableTickets[movieChoice]}");
                    break;
                case 4:
                    Console.WriteLine("Returning to movie selection...");
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }
}

