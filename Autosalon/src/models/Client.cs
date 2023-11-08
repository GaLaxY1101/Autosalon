using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{
    public class Client : IHuman
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Client(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
