using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        const float k_MaxHoursBattery = 1.8f;
        private ElectricEngine m_ElectricEngine;

        public ElectricMotorcycle(string i_Model, string i_LicenseNumber, string i_TypeOfLicense, int i_EngineCapacity)
            : base (i_Model, i_LicenseNumber, i_TypeOfLicense, i_EngineCapacity)
        {
            m_ElectricEngine = new ElectricEngine(k_MaxHoursBattery);
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
