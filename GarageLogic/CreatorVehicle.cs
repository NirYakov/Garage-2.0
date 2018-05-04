﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal static class CreatorVehicle
    {
        internal static Vehicle CreateVehicle(eVeicleType i_TypeOfVehicleToCreate, string i_Model, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn = null;

            switch (i_TypeOfVehicleToCreate)
            {
                case eVeicleType.CreateElectricCar:
                    vehicleToReturn = new ElectricCar(i_Model, i_LicenseNumber, "Blue", (byte)4);
                    break;
                case eVeicleType.CreateFuelCar:
                    vehicleToReturn = new FuelCar(i_Model, i_LicenseNumber, "Blue", (byte)4);
                    break;
                case eVeicleType.CreateElectricMotorcycle:
                    vehicleToReturn = new ElectricMotorcycle(i_Model, i_LicenseNumber, "A1", 500);
                    break;
                case eVeicleType.CreateFuelMotorcycle:
                    vehicleToReturn = new FuelMotorcycle(i_Model, i_LicenseNumber, "A1", 500);
                        break;
                case eVeicleType.CreateFuelTruck:
                    vehicleToReturn = new FuelTruck(i_Model, i_LicenseNumber, 12);
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
