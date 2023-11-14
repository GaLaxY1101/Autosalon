using Autosalon.src.JoinModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    public enum transmissionTypesEnum { automatic, manual, robotized }
    public interface ITransmission
    {
        [Key]
        int id { get; set; }
        String Title { get; set; }

        public transmissionTypesEnum TransmissionType { get; set; }

        public List<ModelTransmissionLink> ModelTransmissionLinks { get; set; }
    }
}
