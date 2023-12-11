using Autosalon.src.models;
using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.JoinModels
{
    public class ModelTransmissionLink
    {
        
        public virtual Model? Model { get; set; }
        public int ModelId {  get; set; }

        public virtual Transmission? Transmission { get; set; }
        public int TransmissionId { get; set; }
        public ModelTransmissionLink() { }

        public ModelTransmissionLink(Model? model, int modelId, Transmission? transmission)
        {
            Model = model;
            ModelId = modelId;
            Transmission = transmission;
            TransmissionId = transmission!.id;
        }
    }
}
