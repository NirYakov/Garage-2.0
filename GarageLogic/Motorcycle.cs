using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        const int k_MaxOfEngineCapacity = 7_000;
        const float k_MaxAirPressure = 30;
        const byte k_NumOfWheels = 2;

        protected int m_EngineCapacity;
        protected eTypeOfLicense m_TypeOfLicense;

        public Motorcycle(string i_Model, string i_LicenseNumber, string i_TypeOfLicense, int i_EngineCapacity , Engine i_EngineToVehicle)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_EngineToVehicle)
        {
            TypeOfLicense = i_TypeOfLicense;
            EngineCapacity = i_EngineCapacity;
            initWheelsList("Unknown", 0, k_MaxAirPressure, k_NumOfWheels);
        }

        public override void InitializationOfVariousVehicle(params object[] i_Details)
        {
            TypeOfLicense = (string)i_Details[0];
            EngineCapacity = (int)i_Details[1];
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                if (value >= 0 && value <= k_MaxOfEngineCapacity)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, k_MaxOfEngineCapacity, 0);
                }


            }
        }

        public string TypeOfLicense
        {
            get
            {
                return m_TypeOfLicense.ToString();
            }

            set
            {
                if (Enum.TryParse<eTypeOfLicense>(value, out eTypeOfLicense someTypeLicense))
                {
                    m_TypeOfLicense = someTypeLicense;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        // book i not sure about all use in enum check this 
        public enum eTypeOfLicense : byte
        {
            A = 1,
            A1,
            B1,
            B2
        }
    }
}

