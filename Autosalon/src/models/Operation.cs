using autosalon_classes.src.Interfaces;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autosalon.src.models
{
    public enum OperationStatuses { Completed, Pending, NotPaid, Cancelled }
    public class Operation
    {
        [Key] // Id will be a Primary key in db.
        public int Id {  get; set; }
        public DateTime DateOfOperation { get; set; }
        
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }
        public Client? Client { get; set; }


        //public Autosalon Autosalon { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        public IEmployee? Employee { get; set; }

        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public int Amount { get; set; }

        public OperationStatuses Status { get; set; }

        public Operation( Employee employee, Client client, OperationStatuses operationStatus) //Auto auto, Autosalon autosalon,
        {
            //Auto = auto;
            DateOfOperation = DateTime.Now;
            Client = client;
            //Autosalon = autosalon;
            Employee = employee;
            Status = operationStatus;
            //Autosalon.SellCar(auto);
        }

        public Operation()
        {

        }
    }
}
