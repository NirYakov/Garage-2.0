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
        private ElectricEngineOld m_ElectricEngine;
        
        public ElectricCar(string i_Model, string i_LicenseNumber, string i_CarColor, byte i_NumOfDoors)
            : base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor)
        {
            m_ElectricEngine = new ElectricEngineOld(k_MaxHoursBattery);
            m_PercentOfEnergy = 0;
        }

        public float BatteryHoursLeft
        {
            get
            {
                return m_ElectricEngine.BatteryHoursLeft;
            }
        }

        public float MaxHoursBattery
        {
            get
            {
                return m_ElectricEngine.MaxHoursBattery;
            }

        }

        public void ChargingBattery(float i_AmoutOfEnergyToAdd)
        {
            m_ElectricEngine.ChargingBattery(i_AmoutOfEnergyToAdd);
            m_PercentOfEnergy = m_ElectricEngine.BatteryHoursLeft / m_ElectricEngine.MaxHoursBattery;

        }


    }
}
