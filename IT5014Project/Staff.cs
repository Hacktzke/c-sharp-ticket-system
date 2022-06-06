using System;
namespace IT5014Project
{
    public class Staff
    {
        private string firstName;
        private string lastName;
        private string email;
        private string staffID;

        //properties with getters and setters link to the private fields.
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string StaffID { get => staffID; set => staffID = value; }

        public Staff()
        {

        }
        //This constructor is called when an email is not specified.
        public Staff(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = "Not Specified";
            staffID = (firstName + lastName[0]).ToUpper();
        }

        //Staff objects and ID are made through the constructor below.
        public Staff(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            staffID = (firstName + lastName[0]).ToUpper();
        }
    }
}
