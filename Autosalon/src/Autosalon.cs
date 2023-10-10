using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace autosalon_classes
{
    class Autosalon
    {
        public List<Auto> AvailableCars { get; set; }
        public List<Auto> SoldCars { get; set; }
        public String Title {  get; set; }
        public String Address {  get; set; }
       
        public void SellCar(Auto autoToSell)
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
            AvailableCars = new List<Auto>();
            SoldCars = new List<Auto>();
        }
    }
}
