using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ElectricEngine
    {
        private float m_BatteryHoursLeft;
        private readonly float r_MaxHoursBattery;

        public ElectricEngine(float i_MaxHoursBattery)
        {
            r_MaxHoursBattery = i_MaxHoursBattery;
            m_BatteryHoursLeft = 0f;
        }

        public float BatteryHoursLeft
        {
            get
            {
                return m_BatteryHoursLeft;
            }
        }

        public float MaxHoursBattery
        {
            get
            {
                return r_MaxHoursBattery;
            }

        }

        public void ChargingBattery(float i_AmoutOfEnergyToAdd)
        {
            if ((m_BatteryHoursLeft + i_AmoutOfEnergyToAdd) <= r_MaxHoursBattery)
            {
                m_BatteryHoursLeft += i_AmoutOfEnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(null, r_MaxHoursBattery - m_BatteryHoursLeft, 0);
            }
        }
    }
}