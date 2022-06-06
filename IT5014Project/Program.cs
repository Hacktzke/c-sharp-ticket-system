using System.Collections.Generic;
using System.Text;
using System;

namespace IT5014Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //This list stores info about tickets submitted
            List<Ticket> Tickets = new List<Ticket>();
            List<Ticket> ClosedTickets = new List<Ticket>();
            Console.WriteLine("Welcome to your Ticketing Prototype System,");
            string program = "on";
            while (program == "on")
            {
                try
                {
                    Console.WriteLine("\n* To submit a ticket type \"T\".");
                    Console.WriteLine("* To log into the Helpdesk type \"H\".");
                    Console.WriteLine("* To close the program type \"E\".\n");
                    
                    char status = Convert.ToChar(Console.ReadLine().ToUpper());
                    if (status == 'T')
                    {
                        string running = "yes";
                        while (running == "yes")
                        {
                            string enterFirstName;
                            string enterLastName;
                            string enterEmail;
                            string enterDescription;
                            string enterStaffID;

                            
                            
                            try
                            {
                                //This block is run if the user is a staff member submiting a ticket
                                Console.Write("Are you a registered staff member? (Y/N) ");
                                char response = Convert.ToChar(Console.ReadLine().ToUpper());
                                if (response == 'N')
                                {
                                    Console.Write("Enter your first name: ");
                                    enterFirstName = Convert.ToString(Console.ReadLine());
                                    Console.Write("Enter your last name: ");
                                    enterLastName = Convert.ToString(Console.ReadLine());
                                    Console.Write("Enter your email: ");
                                    enterEmail = Convert.ToString(Console.ReadLine());
                                    Staff objStaff = new Staff(enterFirstName, enterLastName, enterEmail);
                                    Console.WriteLine("\nYour new Staff ID is: " + objStaff.StaffID);
                                    Console.WriteLine("\n************************\n");
                                    Console.WriteLine("Lets submit a ticket..");
                                    Console.Write("Enter your ticket description: ");
                                    enterDescription = Convert.ToString(Console.ReadLine());
                                    Console.Write("Would you like to use your firstname and email in the ticket? (Y/N) ");
                                    char useNameEmail = Convert.ToChar(Console.ReadLine().ToUpper());
                                    if (useNameEmail == 'Y')
                                    {
                                        Ticket objticket = new Ticket(objStaff.StaffID, enterFirstName, enterEmail, enterDescription);
                                        Tickets.Add(objticket);
                                    }
                                    else
                                    {
                                        Ticket objticket = new Ticket(objStaff.StaffID, enterDescription);
                                        Tickets.Add(objticket);
                                    }

                                    Console.Write("Would you like to enter another ticket? (Y/N) ");
                                    char list_Another = Convert.ToChar(Console.ReadLine().ToUpper());
                                    if (list_Another == 'N')
                                    {
                                        running = "No";// this will finish the while loop and take the user back to the dashboard.
                                    }
                                }
                                else if (response == 'Y') //this code is executed if the user selects Y
                                {
                                    Console.Write("Enter your staff ID: ");
                                    enterStaffID = Convert.ToString(Console.ReadLine().ToUpper());
                                    Console.Write("Enter your ticket description: ");
                                    enterDescription = Convert.ToString(Console.ReadLine());

                                    Console.Write("Would you like to use your firstname and email in the ticket? (Y/N)  ");
                                    char useNameEmail = Convert.ToChar(Console.ReadLine().ToUpper());
                                    if (useNameEmail == 'Y')
                                    {
                                        Console.Write("Please confirm your firstname: ");
                                        enterFirstName = Convert.ToString(Console.ReadLine());
                                        Console.Write("Please confirm your email: ");
                                        enterEmail = Convert.ToString(Console.ReadLine());
                                        Ticket objticket = new Ticket(enterStaffID, enterFirstName, enterEmail, enterDescription);
                                        Tickets.Add(objticket);
                                    }
                                    else
                                    {
                                        Ticket objticket = new Ticket(enterStaffID, enterDescription);// New ticket created through a constructor.
                                        Tickets.Add(objticket);//The object is automatically added to the list
                                    }

                                    Console.Write("Would you like to enter another ticket? (Y/N)");
                                    char list_Another = Convert.ToChar(Console.ReadLine().ToUpper());
                                    if (list_Another == 'N')
                                    {
                                        running = "No";
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR: Incorrect key, please try again.");//If an incorrect imput is made this will notify the user.
                                    
                                }

                            }
                            catch
                            {
                                Console.WriteLine("\nERROR: Incorrect input, please try again.");//This will catch any exceptions to prevent the program from crashing
                            }
                        }
                    }

                    else if (status == 'H')
                    {
                        Console.WriteLine("************************");//These line will help divide up the code making it more readable to the user,
                        Console.WriteLine("*  Helpdesk Dashboard  *");
                        string running = "yes";
                        while (running == "yes")
                        {

                            int list_count = Tickets.Count;
                            TicketStats.DisplayStats();//calls method in the Ticket Class.
                            Console.WriteLine("************************\n");
                            Console.WriteLine("Would you like to:\n");
                            Console.WriteLine("* DISPLAY tickets? Type \"display\".");
                            Console.WriteLine("* RESOLVE a ticket? Type \"resolve\".");
                            Console.WriteLine("* REOPEN a ticket? Type \"reopen\".");
                            Console.WriteLine("* SUBMIT a ticket? Type \"submit\".");
                            Console.WriteLine("* END program? Type \"end\".\n");

                            
                            try
                            {
                                string decision = Convert.ToString(Console.ReadLine().ToLower());
                                if (decision == "display")
                                {

                                    Console.WriteLine("\n********PRINTING TICKETS********\n");
                                    list_count = Tickets.Count;
                                    for (int i = 0; i < list_count; i++)//The for loop prints alll ticket in the Ticket list.
                                    {
                                        Tickets[i].DisplayTickets();//Calls method from Ticket Class.
                                    }

                                }

                                else if (decision == "reopen")
                                {
                                    Console.WriteLine("Which ticket number would you like to reopen? ");
                                    int numberToReopen = Convert.ToInt32(Console.ReadLine());

                                    for (int i = 0; i < list_count; i++)
                                    {
                                        Ticket tempobj = Tickets[i];
                                        if (tempobj.getNum() == numberToReopen)//Method called from Ticket Class.
                                        {
                                            tempobj.ReopenTicket();//Method called from Ticket Class.
                                        }
                                    }
                                }
                                else if (decision == "resolve")
                                {
                                    Console.WriteLine("\nWhich ticket number would you like to resolve? ");
                                    int numberToResolve = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("What is your response? ");
                                    string response = Convert.ToString(Console.ReadLine());
                                    for (int i = 0; i < list_count; i++)//This for loop matches the number to resolve to the ticket number in the list.
                                    {
                                        Ticket tempobj = Tickets[i];
                                        if (tempobj.getNum() == numberToResolve)
                                        {
                                            tempobj.RespondTicket(response);//This method is in the Ticket Class and changes the value of the response.
                                        }
                                    }
                                }

                                else if (decision == "end")
                                {
                                    running = "no";//The code ends the while loop if "end" is typed.
                                }
                                else if (decision == "submit")
                                {
                                    string running2 = "yes";
                                    while (running2 == "yes")
                                    {
                                        string enterFirstName;
                                        string enterLastName;
                                        string enterEmail;
                                        string enterDescription;
                                        string enterStaffID;

                                        try//The code below is used again from above to submit a ticket but from the helpdesk end.
                                        {
                                            Console.Write("Are you a registered staff member? (Y/N) ");
                                            char response = Convert.ToChar(Console.ReadLine().ToUpper());
                                            if (response == 'N')
                                            {
                                                Console.Write("Enter your first name: ");
                                                enterFirstName = Convert.ToString(Console.ReadLine());
                                                Console.Write("Enter your last name: ");
                                                enterLastName = Convert.ToString(Console.ReadLine());
                                                Console.Write("Enter your email: ");
                                                enterEmail = Convert.ToString(Console.ReadLine());
                                                Staff objStaff = new Staff(enterFirstName, enterLastName, enterEmail);
                                                Console.WriteLine("\nYour new Staff ID is: " + objStaff.StaffID);
                                                Console.WriteLine("\n************************\n");
                                                Console.WriteLine("Lets submit a ticket..");
                                                Console.Write("Enter your ticket description: ");
                                                enterDescription = Convert.ToString(Console.ReadLine());
                                                Console.Write("Would you like to use your firstname and email in the ticket? (Y/N) ");
                                                char useNameEmail = Convert.ToChar(Console.ReadLine().ToUpper());
                                                if (useNameEmail == 'Y')
                                                {
                                                    Ticket objticket = new Ticket(objStaff.StaffID, enterFirstName, enterEmail, enterDescription);//Constructor with all attributes.
                                                    Tickets.Add(objticket);//Adds new object to the list automatically.
                                                }
                                                else
                                                {
                                                    Ticket objticket = new Ticket(objStaff.StaffID, enterDescription);//Constructor with miminal attributes.
                                                    Tickets.Add(objticket);
                                                }

                                                Console.Write("Would you like to enter another ticket? (Y/N) ");
                                                char list_Another = Convert.ToChar(Console.ReadLine().ToUpper());
                                                if (list_Another == 'N')
                                                {
                                                    running2 = "No";
                                                }
                                            }
                                            else if (response == 'Y')
                                            {
                                                Console.Write("Enter your staff ID: ");
                                                enterStaffID = Convert.ToString(Console.ReadLine().ToUpper());
                                                Console.Write("Enter your ticket description: ");
                                                enterDescription = Convert.ToString(Console.ReadLine());

                                                Console.Write("Would you like to use your firstname and email in the ticket? (Y/N)  ");
                                                char useNameEmail = Convert.ToChar(Console.ReadLine().ToUpper());
                                                if (useNameEmail == 'Y')
                                                {
                                                    Console.Write("Please confirm your firstname: ");
                                                    enterFirstName = Convert.ToString(Console.ReadLine());
                                                    Console.Write("Please confirm your email: ");
                                                    enterEmail = Convert.ToString(Console.ReadLine());
                                                    Ticket objticket = new Ticket(enterStaffID, enterFirstName, enterEmail, enterDescription);
                                                    Tickets.Add(objticket);
                                                }
                                                else
                                                {
                                                    Ticket objticket = new Ticket(enterStaffID, enterDescription);
                                                    Tickets.Add(objticket);
                                                }

                                                Console.Write("Would you like to enter another ticket? (Y/N)");
                                                char list_Another = Convert.ToChar(Console.ReadLine().ToUpper());
                                                if (list_Another == 'N')
                                                {
                                                    running2 = "No";//This will end the while loop 
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nERROR: Incorrect key, please try again.");
                                            }

                                        }
                                        catch
                                        {
                                            Console.WriteLine("\nERROR: Incorrect input, please try again.");//This catch will prevent the program from crashing if a wrong input is typed.
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR: Please choose on of the five options..");//This will print if the user does not select the option correctly.
                                }
                            }
                            catch
                            {
                                Console.WriteLine("\nERROR: Incorrect input, please try again.");//This catch will prevent the program from crashing if a wrong input is typed.
                            }
                        }
                    }

                    else if (status == 'E')
                    {
                        Console.WriteLine("\nThank you, goodbye.\nCreated by Jeshua Hertzke 20210843");
                        program = "off";//This will end the first while loop and close the program
                    }

                    else
                    {
                        Console.WriteLine("ERROR: Incorrect key, please try again.\n");
                    }
                }

                catch
                {
                    Console.WriteLine("\nERROR: Incorrect input, please try again.");//Closing message saying thank you.
                }
            }
        }
    }
}
