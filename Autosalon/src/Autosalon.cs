using Autosalon.src.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes
{
    class Autosalon
    {
        public List<IVehicle> AvailableCars { get; set; }
        public List<IVehicle> SoldCars { get; set; }
        public String Title {  get; set; }
        public String Address {  get; set; }
       
        public void SellCar(IVehicle autoToSell)
        {
            if (AvailableCars.Contains(autoToSell))
            {
                AvailableCars.Remove(autoToSell);
                SoldCars.Add(autoToSell);
            }
            else throw new ArgumentException("No such car in available cars list.");
            
        }

        public Autosalon(String title,String address)
        {
            Title = title;
            Address = address;
            AvailableCars = new List<IVehicle>();
            SoldCars = new List<IVehicle>();
        }
    }
}
