using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class PetrolEngin 
    {
        private readonly float r_MaxFuelTank;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelTank;

        public PetrolEngin(eFuelType i_FuelType, float i_MaxFuelTank)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelTank = i_MaxFuelTank;
        }

        public void Refuel(string i_FuelType, float i_FuelAmout)
        {
            if (Enum.TryParse<eFuelType>(i_FuelType, out eFuelType currentFuel))
            {
                if (currentFuel == r_FuelType)
                {
                    if (m_CurrentFuelTank + i_FuelAmout <= r_MaxFuelTank)
                    {
                        m_CurrentFuelTank += i_FuelAmout;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(null, r_MaxFuelTank - m_CurrentFuelTank, 0);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new FormatException();
            }
        }

        public string FuelType
        {
            get
            {
                return r_FuelType.ToString();
            }
        }

        public float MaxFuelTank
        {
            get
            {
                return r_MaxFuelTank;
            }
        }

        public float CurrentFuelTank
        {
            get
            {
                return m_CurrentFuelTank;
            }
        }

        public enum eFuelType : byte
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
