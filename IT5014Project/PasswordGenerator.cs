using System;
namespace IT5014Project
{
    public static class PasswordGenerator
    {
        public static string NewPassword(string staff, int ticketNumber)
        {
            //New password is generated below. Substring selects only the amount wanted. ("X") converts it to hexidecimal.
            string fName = staff.Substring(0, 2);
            string strTicket = ticketNumber.ToString("X");
            string strTime = DateTime.Now.ToString();
            string toHexTime = strTime.Substring(0, 4);
            //The code below removes the "/" in the timestamp so only three numbers are selected.
            toHexTime = toHexTime.Replace("/", "");
            int intTime = Convert.ToInt32(toHexTime);
            string hexTime = intTime.ToString("X");

            //New password consists of name ticket number and timestamp.
            string newPassword = fName + strTicket + hexTime;
            TicketStats.TicketsClosed++;
            TicketStats.TicketsOpened--;

            //returns password when called.
            return newPassword;
        }
    }
}
