using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src
{
    public enum OperationStatuses { Completed, Pending, NotPaid, Cancelled}
    internal class Operation
    {
        public DateTime DateOfOperation { get; set; }
        public Client Client { get; set; }
        public Autosalon Autosalon { get; set; }
        public IEmployee Employee { get; set; }
        public Auto Auto { get; set; }
        public int Amount { get; set; }

        public OperationStatuses Status { get; set; }

        public Operation(Autosalon autosalon, Employee employee, Client client, Auto auto,OperationStatuses operationStatus )
        {
            Auto = auto;
            DateOfOperation = DateTime.Now;
            Client = client;
            Autosalon = autosalon;
            Employee = employee;
            Status = operationStatus;
            Autosalon.SellCar(auto);
        }
    }
}
