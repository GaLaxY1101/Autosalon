using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    public enum transmissionTypesEnum { automatic, manual, robotized }
    internal interface ITransmission
    {
        String Title { get; set; }

        public transmissionTypesEnum TransmissionType { get; set; }
    }
}
