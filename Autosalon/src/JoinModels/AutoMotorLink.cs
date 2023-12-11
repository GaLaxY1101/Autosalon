using Autosalon.src.models;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.JoinModels
{
    public class AutoMotorLink
    {
        public virtual Auto? Auto {  get; set; }

        public int AutoId {  get; set; }

        public virtual Motor? Motor { get; set; }

        public int MotorId { get; set; }

        public AutoMotorLink() { }

        public AutoMotorLink(Auto auto, int autoId, Motor motor)
        {
            Auto = auto;
            AutoId = autoId;
            Motor = motor;
        }
    }
}
