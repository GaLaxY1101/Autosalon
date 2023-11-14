using Autosalon.src.JoinModels;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autosalon.src.models
{

    public class Transmission : ITransmission
    {
        public int id { get; set; }
        
        public string Title {  get; set; }

        public transmissionTypesEnum TransmissionType { get; set; }
        public int SpeedCount { get; set; }
        public List<ModelTransmissionLink> ModelTransmissionLinks {  get; set; } = new List<ModelTransmissionLink>();

        public List<Auto> Autos { get; set; } = new List<Auto>();
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
