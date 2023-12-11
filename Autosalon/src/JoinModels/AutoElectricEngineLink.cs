using Autosalon.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.JoinModels
{
    public class AutoElectricEngineLink
    {
        public virtual Auto? Auto { get; set; }

        public int AutoId { get; set; }

        public virtual ElectricEngine? ElectricEngine { get; set; }

        public int ElectricEngineId { get; set; }

        public AutoElectricEngineLink() { }

        public AutoElectricEngineLink(Auto? auto, int autoId, ElectricEngine electricEngine, int electricEngineId)
        {
            Auto = auto;
            AutoId = autoId;
            ElectricEngine = electricEngine;
            ElectricEngineId = electricEngineId;
        }
    }
}
