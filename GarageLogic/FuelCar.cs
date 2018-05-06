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

        public FuelCar(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new FuelEngine(k_MaxFuelTank,eFuelType.Octan98))
        {
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
type of fule is:{1}  , Fuel status is:{2}%", base.ToString(), eFuelType.Octan98, m_PercentOfEnergy);
        }
    }
}
