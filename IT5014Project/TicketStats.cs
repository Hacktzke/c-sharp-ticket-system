using System;
namespace IT5014Project
{
    public static class TicketStats
    {
        //Ticket statistics created below, they are encapsulated witha default value of 0.
        private static int ticketsCreated = 0;
        private static int ticketsOpened = 0;
        private static int ticketsClosed = 0;

        //Getters and setter below allow access to the private variables.
        public static int TicketsCreated { get => ticketsCreated; set => ticketsCreated = value; }
        public static int TicketsOpened { get => ticketsOpened; set => ticketsOpened = value; }
        public static int TicketsClosed { get => ticketsClosed; set => ticketsClosed = value; }

        public static void DisplayStats()
        {
            //Displays ticket stats when called.
            Console.WriteLine("************************\n");
            Console.WriteLine($"Displaying Ticket Statistics\n\nTickets created: {ticketsCreated}\nTickets Resolved: {ticketsClosed}\nTickets To Solve: {ticketsOpened}\n");
        }

    }
}
