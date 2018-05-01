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
            ElectricCar vehicleToReturn = new GarageLogic.ElectricCar("max", "3452", "Blue", (byte)4);
            return vehicleToReturn;
        }
    }
}
