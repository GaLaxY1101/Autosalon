using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    public enum EmployeePositions { Manager, Seller, Director, Cleaner, Mechanic, CallCenterOperator }
    internal interface IEmployee
    {
        EmployeePositions Position { get; set; }
    }
}
