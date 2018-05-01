using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public static class CreatorVehicle
    {
        public static Vehicle CreateVehicle(string i_Details)
        {
            ElectricCar vehicleToReturn = null;
            string typeOfVeicle = i_Details.Substring(0,i_Details.IndexOf(","));

            if (Enum.TryParse<eCarType>(typeOfVeicle, out eCarType someType))
            {
                switch(someType)
                {
                    case eCarType.CreateElectricCar:
                        vehicleToReturn = new GarageLogic.ElectricCar("max", "3452", "Blue", (byte)4);
                        break;
                }
                return vehicleToReturn;
            }
            else
            {
                throw new FormatException();
            }
                      
           
        }

        public enum eCarType : byte
        {
            CreateElectricCar,
        }
    }
}
