using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricEngine
    {
        protected float m_BatteryHoursLeft;
        protected readonly float m_MaxHoursBattery;

        public ElectricEngine(float i_MaxHoursBattery)
        {
            m_MaxHoursBattery = i_MaxHoursBattery;
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
                return m_MaxHoursBattery;
            }

        }

        public void ChargingBattery(float i_AmoutOfEnergyToAdd)
        {
            if ((m_BatteryHoursLeft + i_AmoutOfEnergyToAdd) <= m_MaxHoursBattery)
            {
                m_BatteryHoursLeft += i_AmoutOfEnergyToAdd;
               // m_PercentOfEnergy = m_BatteryHoursLeft / m_MaxHoursBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(null, m_MaxHoursBattery - m_BatteryHoursLeft, 0);
            }
        }
    }
}
