using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public static class VehicleCreator
    {
        public static Vehicle CreateVehicle(eVehicleOption i_ChonsenVehicle, string i_LicenceNum, string i_Model)
        {
            Vehicle newVehicle = null;
            switch (i_ChonsenVehicle)
            {
                case eVehicleOption.FuelCar:
                    newVehicle = new FuelCar(i_LicenceNum, i_Model);
                    break;
                case eVehicleOption.ElecticCar:
                    newVehicle = new ElectricCar(i_LicenceNum, i_Model);
                    break;
                case eVehicleOption.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(i_LicenceNum, i_Model);
                    break;
                case eVehicleOption.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_LicenceNum, i_Model);
                    break;
                case eVehicleOption.FuelTrack:
                    newVehicle = new FuelTrack(i_LicenceNum, i_Model);
                    break;
            }

            return newVehicle;
        }

        public static void VehiclePropertise(Vehicle i_Vehicle, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            i_Vehicle.FillAirInWheels(i_CurrentAirPressure);
            i_Vehicle.FillNameOfWheels(i_ManufacturerName);
        }

        public static void CarPropertise(Vehicle i_Car, byte i_NumOfDoors, Car.eCarColor i_CarColor)
        {
            Car car = i_Car as Car;

            if (car != null)
            {
                car.DoorsCount = i_NumOfDoors;
                car.CarColor = i_CarColor;
            }
            else
            {
                throw new Exception();   // to change
            }
        }

        public static void MotorcyclePropertise(Vehicle i_Moto, int i_EngineCapacity, Motorcycle.eTypeOfLicense typeOfLicense)
        {
            Motorcycle motorcycle = i_Moto as Motorcycle;
            if (motorcycle != null)
            {
                motorcycle.EngineCapacity = i_EngineCapacity;
                motorcycle.TypeOfLicense = typeOfLicense;
            }
            else
            {
                throw new Exception(); // to change
            }
        }

        public static void TrackPropertise(Vehicle i_Track, float i_TrunkCapacity, bool i_IsHaveCoolTrunk)
        {
            FuelTrack track = i_Track as FuelTrack;

            if (track != null)
            {
                track.HaveCoolTrunk = i_IsHaveCoolTrunk;
                track.TrunkCapacity = i_TrunkCapacity;
            }
            else
            {
                throw new Exception();   // to change
            }
        }
    }
}
