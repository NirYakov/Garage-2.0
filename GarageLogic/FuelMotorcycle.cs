using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        const float k_MaxFuelTank = 6f;

        public FuelMotorcycle(string i_Model, string i_LicenseNumber)
            : base(i_Model, i_LicenseNumber, new FuelEngine(k_MaxFuelTank, eFuelType.Octan96))
        {
        }
    }
}