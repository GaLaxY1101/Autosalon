using autosalon_classes.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.src.Interfaces
{
    public enum Colours
    {
        black,
        white,
        red,
        yellow,
        orange,
        blue
    }
    public interface IVehicle
    {
        public String Title { get; set; }

        public String SerialNumber { get; set; }

        public int Mass { get; set; }

        public Colours Colour { get; set; }
    }
}

