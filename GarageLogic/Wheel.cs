using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if(value <= m_MaxAirPressure && value >= 0)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, m_MaxAirPressure, 0);
                }                
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            private set
            {
                m_MaxAirPressure = value;
            }
        }

        public void AirInflation(float i_AmountOfAirToAdd)
        {
            if (((m_CurrentAirPressure + i_AmountOfAirToAdd) <= m_MaxAirPressure) && (i_AmountOfAirToAdd >= 0))
            {
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
            else
            {                                       // it is max that you can insert in your "tank"
                throw new ValueOutOfRangeException(null, m_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }

        public override string ToString()
        {
            return string.Format("Wheel details: Manufacturer Name :{0} , Current Air Pressure : {1}", ManufacturerName, CurrentAirPressure);
        }
    }
}
