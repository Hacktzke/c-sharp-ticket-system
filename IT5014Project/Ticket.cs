using System;

namespace IT5014Project
{
    public class Ticket : Staff
    {
        //Common ticket info below.
        private static int counter = 2000;
        private int ticketNumber;
        private string description;
        private string response = "Not Yet Provided";
        private string ticketstatus = "Open";

        //properties with getters and setters to access private fields.
        public string Description { get => description; set => description = value; }
        public string Response { get => response; set => response = value; }
        public string Ticketstatus { get => ticketstatus; set => ticketstatus = value; }
        public int TicketNumber { get => ticketNumber; set => ticketNumber = value; }

        //Submitting a ticket through constructors with all details below. Contains method for New Password which is returned. Ticket status is changed to closed.
        public Ticket(string staffID, string firstname, string email, string description) : base(staffID, firstname, email)
        {
            this.StaffID = staffID;
            this.FirstName = firstname;
            this.Email = email;
            this.Description = description;
            TicketStats.TicketsCreated++;
            TicketStats.TicketsOpened++;
            counter++;
            ticketNumber = counter;

            if (description.ToLower().Contains("password change"))
            {
                response = "New password generated: " + PasswordGenerator.NewPassword(staffID, ticketNumber);//Calls method in the PasswordGenerator Class.
                ticketstatus = "Closed";
            }
        }

        //Submitting a ticket with only staffID & description. Also contains method for New Password which is returned. Ticket status is changed to closed.
        public Ticket(string staffID, string description)
        {
            this.StaffID = staffID;
            this.FirstName = "Not Specified";
            this.Email = "Not Specified";
            this.Description = description;
            TicketStats.TicketsCreated++;
            TicketStats.TicketsOpened++;
            counter++;
            ticketNumber = counter;

            if (description.ToLower().Contains("password change"))
            {
                response = "New password generated: " + PasswordGenerator.NewPassword(staffID, ticketNumber);//Calls method in the PasswordGenerator Class.
                ticketstatus = "Closed";
            }

        }
        //This method returns the ticket number to work with other methods.
        public int getNum()
        {
            return ticketNumber;
        }

        //Calling this method will display all tickets the user.
        public void DisplayTickets()
        {
            {
                Console.WriteLine($"Ticket Number: {ticketNumber} \nTicket Creator: {FirstName} \nStaff ID: {StaffID} \nEmail: {Email} \nDescription: {description} \nResponse: {response} \nTicket Status: {ticketstatus}\n");

            }
        }

        //Option for IT to provide to a ticket a response below. Method closes ticket and update stats.
        public void RespondTicket(string response)
        {
            this.response = response;
            ticketstatus = "Closed";
            Console.WriteLine("\nTICKET NOW CLOSED\n");
            TicketStats.TicketsClosed++;
            TicketStats.TicketsOpened--;
        }

        //Option for IT to reopen a ticket. Method reopens ticket and update stats.
        public void ReopenTicket()
        {
            ticketstatus = "Reopened";
            Console.WriteLine("\nTICKET NOW REOPENED\n");
            TicketStats.TicketsOpened++;
            TicketStats.TicketsClosed--;
        }
    }
}
