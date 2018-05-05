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

    }
}
