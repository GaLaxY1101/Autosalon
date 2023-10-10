using autosalon_classes.src.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace autosalon_classes
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
    class Model
    {
        public List<IEngine> AvailableMotors { get; set; } // список моторів, доступних на дану модель
        public List<Transmission> AvailableTransmissions { get; set; }

        public String Brand { get; set; }
        public String Title { get; set; }
        public Drives ModelDrive { get; set; } // привод
        public BodyTypes BodyType { get; set; }


        public Model(String Brand,String Title, Drives ModelDrive, BodyTypes bodyType)
        {
            AvailableMotors = new List<IEngine>();
            AvailableTransmissions = new List<Transmission>();
            this.ModelDrive = ModelDrive;
            this.BodyType = bodyType;
            this.Brand = Brand;
            this.Title = Title;
        }

        
    }
}
