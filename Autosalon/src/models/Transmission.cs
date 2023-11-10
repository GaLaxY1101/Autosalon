using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{

    public class Transmission : ITransmission
    {
        public int id { get; set; }
        
        public string Title {  get; set; }

        public transmissionTypesEnum TransmissionType { get; set; }
        public int SpeedCount { get; set; }


        Transmission() 
        {
            Title = "Not set";
        }

        public Transmission(string transmissionName, transmissionTypesEnum transmissionType, int transmissionSpeedCount)
        {
            Title = transmissionName;
            TransmissionType = transmissionType;
            SpeedCount = transmissionSpeedCount;
        }
    }
}
