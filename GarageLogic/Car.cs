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

        public Car(string i_Model, string i_LicenseNumber, Engine i_EngineToVehicle)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_EngineToVehicle)
        {
            initWheelsList("Unknown", 0, k_MaxAirPressure, k_NumOfWheels);
        }

        public override void InitializationOfVariousVehicle(params object[] i_Details)
        {
            CarColor = (string)i_Details[0];
            DoorsCount = (byte)i_Details[1];
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
