using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src
{
    internal class ElectricEngine : IEngine
    {
        public string Title
        {
            get => this.Title;
            set
            {
                if (value != null && value != "") this.Title = value;
                else throw new ArgumentException("Motor must have a title.");
            }

        }

        public int HorsePower
        {
            get => this.HorsePower;
            set
            {
                if (value > 0) HorsePower = value;
                else throw new ArgumentException("Motor can't have count of horse power < 0.");
            }
        }

        public int Power { get; set; }

        public FuelTypes FuelType { get; set; }

        public float MotorVolume
        {
            get => this.MotorVolume;
            set
            {
                if (value > 0) MotorVolume = value;
                else throw new ArgumentException("Motor can't have volume < 0.");
            }
        }

        public int Torque
        {
            get => this.Torque;
            set
            {
                if (value > 0) MotorVolume = value;
                else throw new ArgumentException("Motor's torque must be > 0.");
            }
        }
 
    }
}
