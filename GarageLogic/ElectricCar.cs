using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricCar : Car
    {
        const float k_MaxHoursBattery = 3.2f;
        const byte k_NumOfWheels = 4;
        private ElectricEngine electricEngine;
        

        public ElectricCar(string i_Model, string i_LicenseNumber, string i_CarColor, byte i_NumOfDoors)
            : base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor)
        {
            electricEngine = new ElectricEngine(k_MaxHoursBattery);
            m_PercentOfEnergy = 0;
        }
        
    }
}
