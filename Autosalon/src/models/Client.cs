using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autosalon.src.models
{
    public class Client : IHuman
    {
        public int Id { get; set; }
        [Required]

        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }

        public int Age { get; set; }
        [Required]
        public string? PassportNumber { get; set; }

        public List<Operation> Operations { get; set; }
        public Client() { }
        public Client(string firstName, string lastName, string phoneNumber, int age, string passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Age = age;
            PassportNumber = passportNumber;
        }
    }
}
