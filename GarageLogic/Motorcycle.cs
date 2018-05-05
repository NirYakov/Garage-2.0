using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        const int k_MaxOfEngineCapacity = 7_000;
        const float k_MaxAirPressure = 30;
        const byte k_NumOfWheels = 2;

        protected int m_EngineCapacity;
        protected eTypeOfLicense m_TypeOfLicense;

        internal Motorcycle(string i_LicenseNumber, string i_Model, Engine i_EngineToVehicle)
            : base(i_LicenseNumber, i_Model, k_NumOfWheels, i_EngineToVehicle)
        {
            initWheelsList("Unknown", 0, k_MaxAirPressure, k_NumOfWheels);
        }       

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            internal set
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

        public eTypeOfLicense TypeOfLicense
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {               
                    m_TypeOfLicense = value;
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

