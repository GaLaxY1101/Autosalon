using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes
{
    
    class Transmission : ITransmission
    {
        public String Title
        {
            get
            {
                return Title;
            }
            set
            {
                if (value != null)
                {
                    this.Title = value;
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

        public Transmission(String transmissionName, transmissionTypesEnum transmissionType, int transmissionSpeedCount)
        {
            this.Title =                    transmissionName;
            this.TransmissionType =        transmissionType;
            this.SpeedCount =               transmissionSpeedCount;
        }
    }
}
