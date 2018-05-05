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

        public FuelMotorcycle(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new FuelEngine(k_MaxFuelTank, eFuelType.Octan96))
        {
        }
    }
}