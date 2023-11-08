using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes.src.Interfaces
{
    public enum transmissionTypesEnum { automatic, manual, robotized }
    public interface ITransmission
    {
        String Title { get; set; }

        public transmissionTypesEnum TransmissionType { get; set; }
    }
}
