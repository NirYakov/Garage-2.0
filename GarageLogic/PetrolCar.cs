using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class PetrolCar : Car
    {
        const float k_MaxFuelTank = 45f;
        private PetrolEngin m_PetrolEngin;

        public PetrolCar(string i_Model, string i_LicenseNumber, string i_CarColor, byte i_NumOfDoors)
            : base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor)
        {
            m_PetrolEngin = new PetrolEngin(PetrolEngin.eFuelType.Octan98, k_MaxFuelTank);
            m_PercentOfEnergy = 0;
        }

        public float CurrentFuelTank
        {
            get
            {
                return m_PetrolEngin.CurrentFuelTank;
            }
        }

        public float MaxFuelTank
        {
            get
            {
                return m_PetrolEngin.MaxFuelTank;
            }

        }
        public void Refuel(string i_FuelType, float i_FuelAmout)
        {
            m_PetrolEngin.Refuel(i_FuelType, i_FuelAmout);
            m_PercentOfEnergy = m_PetrolEngin.CurrentFuelTank / m_PetrolEngin.MaxFuelTank;
        }
    }
}
