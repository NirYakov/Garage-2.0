using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ElectricEngine : Engine
    {
        const string k_Electric = "Electric";

        public ElectricEngine(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity)
        {            
        }

        public override string EnergyType
        {
            get
            {
                return k_Electric;
            }
        }

        public override void FillEnergy(float i_AmonutOfEnergy, string i_EnergyType)
        {
            const string Electric = "Electric"; // book nir need to done and do private method to get all together.

            if (Electric == i_EnergyType)
            {
                checkingAmoutAndFillingEnergy(i_AmonutOfEnergy);
            }
            else
            {
                throw new ArgumentException();
            }
        }      
    }
}
