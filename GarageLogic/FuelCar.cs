using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class FuelCar : Car
    {
        const float k_MaxFuelTank = 45f;

        public FuelCar(string i_Model, string i_LicenseNumber)
            : base(i_Model, i_LicenseNumber, new FuelEngine(k_MaxFuelTank,eFuelType.Octan98))
        {
        }
        
    }
}
