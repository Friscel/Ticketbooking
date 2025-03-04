namespace TicketBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WELCOME TO THE TICKET BOOKING SYSTEM");

            int availableTickets = 20;

            string[] actions = new string[] { "[1] View Available Tickets", "[2] Book a Ticket", "[3] Cancel a Ticket", "[4] Exit" };

            Console.WriteLine("ACTIONS");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }

            Console.Write("Enter Action: ");
            int userAction = Convert.ToInt16(Console.ReadLine());

            switch (userAction)
            {
                case 1:
                    Console.WriteLine($"Available tickets: {availableTickets}");
                    break;
                case 2:
                    if (availableTickets > 0)
                    {
                        availableTickets--;
                        Console.WriteLine("Ticket booked successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No tickets available.");
                    }
                    Console.WriteLine($"Remaining tickets: {availableTickets}");
                    break;
                case 3:
                    availableTickets++;
                    Console.WriteLine("Ticket canceled successfully.");
                    Console.WriteLine($"Available tickets: {availableTickets}");
                    break;
                case 4:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid action.");
                    break;
            }
        }
    }
}

