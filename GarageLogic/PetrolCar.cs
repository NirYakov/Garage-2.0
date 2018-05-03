using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class PetrolCar : Car
    {
        const float k_MaxFuelTank = 45f;

        public PetrolCar(string i_Model, string i_LicenseNumber, string i_CarColor, byte i_NumOfDoors)
            : base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor, new FuelEngine(k_MaxFuelTank,eFuelType.Octan98))
        {
        }
        
    }
}
