using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src
{
    internal class Client : IHuman
    {
        public String ID {  get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }

        public Client(String id, String firstName, String lastName, String phoneNumber ) 
        { 
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
