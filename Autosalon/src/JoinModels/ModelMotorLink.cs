using Autosalon.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.JoinModels
{
    public class ModelMotorLink
    {
        public int ModelId { get; set; }
        public virtual Model? Model { get; set; }

        public int MotorId { get; set; }
        public virtual Motor? Motor { get; set; }

        public ModelMotorLink() { }
        public ModelMotorLink(int modelId, Model? model, int motorId, Motor? motor)
        {
            ModelId = modelId;
            Model = model;
            MotorId = motorId;
            Motor = motor;
        }
    }
}
