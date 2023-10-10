using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src
{
    internal class Employee : IHuman, IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public EmployeePositions Position{ get; set; }
    }
}
