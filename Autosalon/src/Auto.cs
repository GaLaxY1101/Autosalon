﻿using System;
using System.Collections.Generic;
using System.Text;
using Autosalon.src.Interfaces;
using autosalon_classes.src.Interfaces;

namespace autosalon_classes
{

    class Auto : IProduct, IVehicle
    {
        public int Price { get; set; }

        public List<IEquipment> Complectation {  get; set; }
        public List<IEngine>  Motors { get; set; }
        public ITransmission Transmission { get; set; }

        public int Milage { get; set; }
        public String SerialNumber { get; set; }
        
        public Model Model { get; set; }

        public int Mass { get; set; }
        public Colours Colour { get; set; }
        string IProduct.Title { get => Model.Brand + " " + Model.Title;}
        string IVehicle.Title { get; set; }

        public Auto(List<IEngine> Motors, Transmission Transmission, BodyTypes BodyType,
                    String SerialNumber, Colours Colour, 
                    Model Model, List<IEquipment> complectation, int milage)
        {
            this.Motors = Motors;
            this.Transmission = Transmission;
            this.SerialNumber = SerialNumber;
            this.Colour = Colour;
            this.Model = Model;
            this.Complectation = complectation;
            this.milage = milage;
        }

    }
}
