using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.models
{
    public class Option : IEquipment
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; } = "No title set";
        public string? Description { get; set; }

        public Option() { }
    }
}
