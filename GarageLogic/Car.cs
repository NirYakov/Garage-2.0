using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        const float  k_MaxAirPressure = 32;
        const byte k_NumOfWheels = 4;
        protected byte m_DoorsCount;
        protected eCarColor m_CarColor;

        internal Car(string i_LicenseNumber, string i_Model, Engine i_EngineToVehicle)
            : base(i_LicenseNumber, i_Model, k_NumOfWheels, i_EngineToVehicle)
        {
        }

        public override void SetWheelsProperty(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaxAirPressure, k_NumOfWheels);
        }

        public byte DoorsCount
        {
            get
            {
                return m_DoorsCount;
            }

            internal set
            {
                if (value >= 2 && value <= 5)
                {
                    m_DoorsCount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 5, 2);
                }
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {                
                    m_CarColor = value;               
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
the car color is:{1} , the count of doors is:{2},", base.ToString(), m_CarColor,m_DoorsCount);
        }

        public enum eCarColor : byte
        {
            Gray,
            Blue,
            White,
            Black
        }
    }
}
