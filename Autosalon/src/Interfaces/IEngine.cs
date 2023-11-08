using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    public enum FuelTypes { Diesel, Petrol, Gasoline, Electricity }
    public interface IEngine
    {
        FuelTypes FuelType { get; set; }
        public String Title { get; set; }
        public int HorsePower { get; set; }

        public int Torque { get; set; }


    }
}
