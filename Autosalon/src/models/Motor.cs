using System;
using System.Collections.Generic;
using System.Text;
using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;

namespace Autosalon.src.models
{
    public class Motor : IEngine
    {
        public int id {  get; set; }
        public string Title
        {
            get => Title;
            set
            {
                if (value != null && value != "") Title = value;
                else throw new ArgumentException("Motor must have a title.");
            }

        }

        public int HorsePower
        {
            get => HorsePower;
            set
            {
                if (value > 0) HorsePower = value;
                else throw new ArgumentException("Motor can't have count of horse power < 0.");
            }
        }

        public FuelTypes FuelType { get; set; }

        public float MotorVolume
        {
            get => MotorVolume;
            set
            {
                if (value > 0) MotorVolume = value;
                else throw new ArgumentException("Motor can't have volume < 0.");
            }
        }

        public int Torque
        {
            get => Torque;
            set
            {
                if (value > 0) MotorVolume = value;
                else throw new ArgumentException("Motor's torque must be > 0.");
            }
        }

        public List<ModelMotorLink> ModelMotorLinks { get; set; } = new List<ModelMotorLink>();

        public List<AutoMotorLink> AutoMotorLinks { get; set; } = new List<AutoMotorLink> { };


        public Motor(string title, FuelTypes motorType, float motorVolume, int horsePower, int torque)
        {
            Title = title;
            FuelType = motorType;
            MotorVolume = motorVolume;
            HorsePower = horsePower;
            Torque = torque;
        }

        public Motor() { }


    }
}
