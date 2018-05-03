using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Car : Vehicle
    {
        const float  k_MaxAirPressure = 32;
        const byte k_NumOfWheels = 4;
        protected byte m_DoorsCount;
        protected eCarColor m_CarColor;

        public Car(string i_Model, string i_LicenseNumber, byte i_DoorCount, string i_CarColor , Engine i_EngineToVehicle)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_EngineToVehicle)
        {
            DoorsCount = i_DoorCount;
            CarColor = i_CarColor;
            initWheelsList("Unknown", 0, k_MaxAirPressure, k_NumOfWheels);
        }

        public byte DoorsCount
        {
            get
            {
                return m_DoorsCount;
            }

            protected set
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

        public string CarColor
        {
            get
            {
                return m_CarColor.ToString();
            }

            set
            {
                if (Enum.TryParse<eCarColor>(value, out eCarColor someColor))
                {
                    m_CarColor = someColor;
                }
                else
                {
                    throw new FormatException();
                }
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
