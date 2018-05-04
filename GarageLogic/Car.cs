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

        internal Car(string i_Model, string i_LicenseNumber, Engine i_EngineToVehicle)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_EngineToVehicle)
        {
            initWheelsList("Unknown", 0, k_MaxAirPressure, k_NumOfWheels);
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

        public enum eCarColor : byte
        {
            Gray,
            Blue,
            White,
            Black
        }
    }
}
