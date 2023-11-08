﻿using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{
    public class ElectricEngine : IEngine
    {
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

        public int Power { get; set; }

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

    }
}