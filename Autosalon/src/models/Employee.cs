﻿using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{
    public class Employee : IHuman, IEmployee
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }

        public EmployeePositions Position { get; set; }

        public Employee(String firstName, String lastName, String phoneNumber, EmployeePositions position ) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Position = position;
        }
    }
}
