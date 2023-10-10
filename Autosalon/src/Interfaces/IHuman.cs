using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    internal interface IHuman
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
    }
}
