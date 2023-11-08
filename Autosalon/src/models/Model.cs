using autosalon_classes.src.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public List<IEngine> AvailableMotors { get; set; } // список моторів, доступних на дану модель
        public List<Transmission> AvailableTransmissions { get; set; }

        public string Brand { get; set; }
        public string Title { get; set; }
        public Drives ModelDrive { get; set; } // привод
        public BodyTypes BodyType { get; set; }


        public Model(string Brand, string Title, Drives ModelDrive, BodyTypes bodyType)
        {
            AvailableMotors = new List<IEngine>();
            AvailableTransmissions = new List<Transmission>();
            this.ModelDrive = ModelDrive;
            BodyType = bodyType;
            this.Brand = Brand;
            this.Title = Title;
        }


    }
}
