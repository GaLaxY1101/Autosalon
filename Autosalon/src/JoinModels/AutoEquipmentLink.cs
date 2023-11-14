using Autosalon.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.JoinModels
{
    public class AutoEquipmentLink
    {
        public Auto? Auto {  get; set; }
        public int AutoId { get; set; }

        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public AutoEquipmentLink() { }

        public AutoEquipmentLink(Auto auto, int autoId, int equipmentId, Equipment equipment)
        {
            Auto = auto;
            AutoId = autoId;
            EquipmentId = equipmentId;
            Equipment = equipment;
        }
    }
}
