using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{

    public class Transmission : ITransmission
    {
        public string Title
        {
            get
            {
                return Title;
            }
            set
            {
                if (value != null)
                {
                    Title = value;
                }
                else
                {
                    throw new ArgumentNullException("Назва коробки передач не може бути пустою.");
                }
            }

        }
        public transmissionTypesEnum TransmissionType { get; set; }
        public int SpeedCount
        {
            get
            {
                return SpeedCount;
            }
            set
            {
                if (value > 0)
                {
                    SpeedCount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Кількість ступеней коробки передач не може бути меншим за 1");
                }
            }
        }

        public Transmission(string transmissionName, transmissionTypesEnum transmissionType, int transmissionSpeedCount)
        {
            Title = transmissionName;
            TransmissionType = transmissionType;
            SpeedCount = transmissionSpeedCount;
        }
    }
}
