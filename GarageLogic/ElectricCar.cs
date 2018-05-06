using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{ 
    internal class ElectricCar : Car
    {
        const float k_MaxHoursBattery = 3.2f;
        
        public ElectricCar(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new ElectricEngine(k_MaxHoursBattery))
        {
        }

        public override string ToString()
        {
            return string.Format(
 @"{0}
Battery status:{1}%", base.ToString(), m_PercentOfEnergy);
        }
    }
}
