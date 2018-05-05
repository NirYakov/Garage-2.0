using System;

namespace GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxEnergyCapacity, eFuelType i_FuelType) : base(i_MaxEnergyCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public override void FillEnergy(float i_AmonutOfEnergy, string i_EnergyType)
        {
            eFuelType currentFuel = (eFuelType)eFuelType.Parse(typeof(eFuelType), i_EnergyType);

            if (currentFuel == r_FuelType)
            {
                checkingAmoutAndFillingEnergy(i_AmonutOfEnergy);
            }
            else
            {
                throw new ArgumentException("Not the right Fuel type.");
            }
        }

        public string FuelType
        {
            get
            {
                return r_FuelType.ToString();
            }
        }
    }    
}

