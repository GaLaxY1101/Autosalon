using Autosalon.src.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace Autosalon.src.models
{
    public class Autosalon
    {
        public virtual List<IVehicle> AvailableCars { get; set; }
        public virtual List<IVehicle> SoldCars { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public void SellCar(IVehicle autoToSell)
        {
            if (AvailableCars.Contains(autoToSell))
            {
                AvailableCars.Remove(autoToSell);
                SoldCars.Add(autoToSell);
            }
            else throw new ArgumentException("No such car in available cars list.");

        }

        public Autosalon(string title, string address)
        {
            Title = title;
            Address = address;
            AvailableCars = new List<IVehicle>();
            SoldCars = new List<IVehicle>();
        }
    }
}
