using System;
using System.Collections.Generic;
using System.Text;
using Autosalon.src.Interfaces;
using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;

namespace Autosalon.src.models
{

    public class Auto : IProduct, IVehicle
    {
        public int Id {  get; set; }
        public int Price { get; set; }

        public virtual List<AutoEquipmentLink> AutoEquipmentLink { get; set; } = new List<AutoEquipmentLink>();
        public virtual List<AutoMotorLink> AutoMotorLink { get; set; } = new List<AutoMotorLink> { };
        public virtual List<AutoElectricEngineLink> AutoElectricEngineLink { get; set; } = new List<AutoElectricEngineLink> { };

        
        public virtual Operation? Operation { get; set; }
        public int OperationId { get; set; }
        public virtual Transmission? Transmission { get; set; }
        public int TransmissionId {  get; set; }
        public int Milage { get; set; }
        public string? SerialNumber { get; set; }

        public int ModelID { get; set; }
        public virtual Model? Model { get; set; }

        public int Mass { get; set; }
        public Colours Colour { get; set; }
        string IProduct.Title { get => Model!.Brand + " " + Model.Title; }
        string IVehicle.Title { get; set; } = "Not set";

        public Auto()
        {

        }
        public Auto(int price, Transmission transmission, int milage, string serialNumber, Model model, int mass, Colours colour)
        {
            Price = price;
            Transmission = transmission;
            Milage = milage;
            SerialNumber = serialNumber;
            Model = model;
            Mass = mass;
            Colour = colour;
        }


    }
}
