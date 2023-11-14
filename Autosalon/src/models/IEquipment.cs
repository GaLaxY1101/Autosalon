using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.models
{
    public class Equipment : IEquipment
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public string? Description { get;set; }

        public List<AutoEquipmentLink>? AutoEquipmentLink { get; set; }
        public Equipment() { }

        public Equipment(int id, string? title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
