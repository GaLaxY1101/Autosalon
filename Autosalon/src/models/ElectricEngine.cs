using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autosalon.src.models
{
    public class ElectricEngine : IEngine
    {
        [Key]
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

        public int Power { get; set; }

        public FuelTypes FuelType { get; set; }

        public int Torque { get; set; }

        public List<ModelElectricEngineLink> ModelElectricEngineLinks { get; set; } = new List<ModelElectricEngineLink>();
        public List<AutoElectricEngineLink> AutoElectricEngineLink { get; set; } = new List<AutoElectricEngineLink> { };
        public ElectricEngine()
        {

        }
        public ElectricEngine(int id, string title, int horsePower, int power, FuelTypes fuelType, int torque)
        {
            this.id = id;
            Title = title;
            HorsePower = horsePower;
            Power = power;
            FuelType = fuelType;
            Torque = torque;
        }
    }
}
