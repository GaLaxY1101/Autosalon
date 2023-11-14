using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace Autosalon.src.models
{
    public enum BodyTypes
    {
        sedan,
        hatchback,
        coupe,
        convertible, //кабріолет
        wagon,
        SUV
    }

    public enum Drives
    {
        frontWheel,
        backWheel,
        fourWheel
    }
    public class Model
    {
        [Key]
        public int id {  get; set; }

        public List<Auto> Autos = new List<Auto>();

        public string? Brand { get; set; }
        public string? Title { get; set; }
        public Drives ModelDrive { get; set; } // привод
        public BodyTypes BodyType { get; set; }

        public Model() { }

        public Model(string Brand, string Title, Drives ModelDrive, BodyTypes bodyType)
        {
            this.ModelDrive = ModelDrive;
            BodyType = bodyType;
            this.Brand = Brand;
            this.Title = Title;
        }
        public List<ModelMotorLink>? MotorLinks { get; set; }
        public List<ModelElectricEngineLink>? ElectricEngineLinks { get; set; }
        public List<ModelTransmissionLink>? ModelTransmissionLinks { get; set; } 

    }
}
