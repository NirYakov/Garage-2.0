using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal static class CreatorVehicle
    {
        public static Vehicle CreateVehicle(eVeicleType i_TypeOfVehicleToCreate, string i_Model, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn = null; 

            switch (i_TypeOfVehicleToCreate)
            {
                case eVeicleType.CreateElectricCar:
                    vehicleToReturn = new ElectricCar(i_Model, i_LicenseNumber);
                    break;
                case eVeicleType.CreateFuelCar:
                    vehicleToReturn = new FuelCar(i_Model, i_LicenseNumber);
                    break;
                case eVeicleType.CreateElectricMotorcycle:
                    vehicleToReturn = new ElectricMotorcycle(i_Model, i_LicenseNumber);
                    break;
                case eVeicleType.CreateFuelMotorcycle:
                    vehicleToReturn = new FuelMotorcycle(i_Model, i_LicenseNumber);
                        break;
                case eVeicleType.CreateFuelTruck:
                    vehicleToReturn = new FuelTrack(i_Model, i_LicenseNumber);
                    break;

            }
            return vehicleToReturn;
            
        }

        public enum eVeicleType : byte
        {
            CreateElectricCar,
            CreateElectricMotorcycle,
            CreateFuelCar,
            CreateFuelMotorcycle,
            CreateFuelTruck
        }
    }
}
