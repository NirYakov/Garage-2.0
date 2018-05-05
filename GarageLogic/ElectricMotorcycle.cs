using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        const float k_MaxHoursBattery = 1.8f;

        public ElectricMotorcycle(string i_LicenseNumber, string i_Model)
            : base (i_LicenseNumber, i_Model, new ElectricEngine(k_MaxHoursBattery))
        {
        }
        
    }
}
