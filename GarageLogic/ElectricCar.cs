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
        
        public ElectricCar(string i_Model, string i_LicenseNumber)
            : base(i_Model, i_LicenseNumber, new ElectricEngine(k_MaxHoursBattery))
        {
        }

    }
}
