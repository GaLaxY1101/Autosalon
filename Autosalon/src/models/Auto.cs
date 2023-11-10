using System;
using System.Collections.Generic;
using System.Text;
using Autosalon.src.Interfaces;
using autosalon_classes.src.Interfaces;

namespace Autosalon.src.models
{

    public class Auto : IProduct, IVehicle
    {
        public int Price { get; set; }

        public List<IEquipment> Complectation { get; set; }
        public List<IEngine> Motors { get; set; }
        public ITransmission Transmission { get; set; }

        public int Milage { get; set; }
        public string SerialNumber { get; set; }

        public Model Model { get; set; }

        public int Mass { get; set; }
        public Colours Colour { get; set; }
        string IProduct.Title { get => Model.Brand + " " + Model.Title; }
        string IVehicle.Title { get; set; } = "Not set";

        public Auto(List<IEngine> Motors, Transmission Transmission, BodyTypes BodyType,
                    string SerialNumber, Colours Colour,
                    Model Model, List<IEquipment> complectation, int milage)
        {
            this.Motors = Motors;
            this.Transmission = Transmission;
            this.SerialNumber = SerialNumber;
            this.Colour = Colour;
            this.Model = Model;
            Complectation = complectation;
            //this.milage = milage;
        }

    }
}
