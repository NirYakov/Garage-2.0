using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    public class SecretariatOfGarage
    {
        private readonly GarageLogic.GarageActs r_Garage;


        public SecretariatOfGarage()
        {
            r_Garage = new GarageLogic.GarageActs();
        }

        public void OpenGarage()
        {
            const byte outOfChoiseRange = 200;
            bool quit = false;
            eGarageAction actionToDo;
            while (!quit)
            {
                //Console.Clear();
                Console.WriteLine(k_MenuMsg);
                actionToDo = (eGarageAction)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);
                quit = doActionInGarage(actionToDo);
            }
        }

        private bool doActionInGarage(eGarageAction option)
        {
            bool quit = false;
            switch (option)
            {
                case eGarageAction.Exit:
                    quit = true;
                    break;
                case eGarageAction.InsertCarToGarage:
                    createNewClint();
                    break;
                case eGarageAction.FullDataForOnwerAndVehicle:
                    Console.WriteLine("insert license number");
                    Console.WriteLine(r_Garage.MsgFullDetailsVehicle(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("worng input , insert again");
                    break;
            }


            return quit;
        }

        public string EnumChoises(Type i_Type) // print all enum choises , all enum need start from 0
        {
            string[] allVehcleTypes = Enum.GetNames(i_Type);
            StringBuilder enumChoise = new StringBuilder(100);
            byte idx = 0;
            foreach (string vehicleType in allVehcleTypes)
            {
                enumChoise.AppendFormat("{0}. {1}{2}", idx++, vehicleType, Environment.NewLine);
            }

            return enumChoise.ToString();
        }

        private void getEnumChoise<T>(Type i_Type, out T i_Choise) where T : struct
        {
            T userChoise;
            while (!(Enum.TryParse(Console.ReadLine(), out userChoise) && Enum.IsDefined(i_Type, userChoise)))
            {
                Console.WriteLine("Wrong input, try again.");
            }

            i_Choise = userChoise;
        }

        private Vehicle createNewVehicle( out eVehicleOption curretVehicle)
        {
            string licenceNum, modelNum;
            Console.WriteLine("insert the licence number");
            licenceNum = Console.ReadLine();
            while (r_Garage.IsAlreadyInGarage(licenceNum))
            {
                Console.WriteLine("The car in already in the garge , insert anther licence number .");
                licenceNum = Console.ReadLine();
            }

            Console.WriteLine(EnumChoises(typeof(eVehicleOption)));
            Console.WriteLine("Insert your number of choice then press 'enter'");
            getEnumChoise(typeof(eVehicleOption), out eVehicleOption currentChoise);
            Console.WriteLine("Insert model for the {0}", currentChoise);
            modelNum = Console.ReadLine();
            Vehicle newVehicle = VehicleCreator.CreateVehicle(currentChoise, licenceNum, modelNum);
            curretVehicle = currentChoise;
            return newVehicle;
        }

        private void createNewClint()
        {
            Vehicle newVehicle = createNewVehicle(out eVehicleOption curretVehicle);
            fillAndAddClintToTheGarage(newVehicle);

            switch (curretVehicle)
            {
                case eVehicleOption.FuelCar:
                case eVehicleOption.ElecticCar:
                    CarPropertise(newVehicle);
                    break;
                case eVehicleOption.FuelMotorcycle:
                case eVehicleOption.ElectricMotorcycle:
                    MotorcyclePropertise(newVehicle);
                    break;
                case eVehicleOption.FuelTrack:
                    TrackPropertise(newVehicle);
                    break;
            }

        }

        private void fillAndAddClintToTheGarage(Vehicle i_NewVehicle)
        {
            string clientName, clientPhoneNumber;
            Console.WriteLine("insert your name");
            clientName = Console.ReadLine();
            Console.WriteLine("insert your phone number");
            clientPhoneNumber = Console.ReadLine();
            r_Garage.InsertNewClint(new Clint(i_NewVehicle, clientName, clientPhoneNumber));
        }

        void VehiclePropertise(Vehicle i_Vehicle)
        {
            string manufacturerNameOfWheels;
            Console.WriteLine("insert name of manufacturer of wheels");
            manufacturerNameOfWheels = Console.ReadLine();
            Console.WriteLine("insert air pressure that you want, if is more than maximum air pressure will be 0");

            if (!float.TryParse(Console.ReadLine(), out float airPressure) || !(airPressure >= 0 && airPressure <= i_Vehicle.MaxAirInWheels))
            {
                airPressure = 0;
            }

            VehicleCreator.VehiclePropertise(i_Vehicle, manufacturerNameOfWheels, airPressure);
        }

        void CarPropertise(Vehicle i_Car) // its private ? -> need to be carPropertise
        {
            Console.WriteLine("Insert plase number of doors between 2 - 5 and then press 'enter' (defualt is 2)");
            if (!byte.TryParse(Console.ReadLine(), out byte numOfDoors) || !(numOfDoors >= 2 && numOfDoors <= 5))
            {
                numOfDoors = 2;
            }

            Console.WriteLine("Now insert your car color");
            Console.WriteLine("Insert your number of choice then press 'enter'"); // to do it in maybe another place the Msg. becuse if commeon.
            Console.WriteLine(EnumChoises(typeof(Car.eCarColor)));
            getEnumChoise(typeof(Car.eCarColor), out Car.eCarColor chosenColor);

            VehicleCreator.CarPropertise(i_Car, numOfDoors, chosenColor);
        }

        void MotorcyclePropertise(Vehicle i_Moto)
        {
            const int MaxEngieCapacity = 7_000;            
            Console.WriteLine(
                "Insert plase Engine Capacity between 0 - {0} and then press 'enter' (defualt is 500)"
                , MaxEngieCapacity);
            if (!int.TryParse(Console.ReadLine(), out int engineCapacity) || !(engineCapacity >= 0 && engineCapacity <= 7_000))
            {
                engineCapacity = 500;
            }

            Console.WriteLine("Choose type of license");           
            getEnumChoise(typeof(Motorcycle.eTypeOfLicense), out Motorcycle.eTypeOfLicense typeOfLicense);
            VehicleCreator.MotorcyclePropertise(i_Moto, engineCapacity, typeOfLicense);
        }

        void TrackPropertise(Vehicle i_Track)
        {
            Console.WriteLine("Insert plase Trunk Capacity between 0 - 600,000 and then press 'enter' (defualt is 100,000)");
            if (!float.TryParse(Console.ReadLine(), out float trunkCapacity) || !(trunkCapacity >= 0 && trunkCapacity <= 600_000f))
            {
                trunkCapacity = 100_000f;
            }

            Console.WriteLine("insert true (any way) if you want Trunk With Cooling Cell, another for Trunk less Cooling Cell");
            if (!bool.TryParse(Console.ReadLine(), out bool isHaveCoolTrunk))
            {
                isHaveCoolTrunk = false;
            }

            VehicleCreator.TrackPropertise(i_Track, trunkCapacity, isHaveCoolTrunk);
        }

        private const string k_MenuMsg =
@"
Menu
============== Insert the number of Action you want and then press 'enter ' ==============
0. Exit
1. Insert car to garage
2. List of vehicles in progress , only licence number .  
3. New vehicle status
4. Fill untill Max wheel air to vehicle's
5. Refuel fuel vehicle
6. Charge electric vehicle
7. Full data for onwer and vehicle";

        private enum eGarageAction : byte
        {
            Exit,
            InsertCarToGarage,
            ListOfVehicles,
            NewCarStatus,
            FillMaxWheelAir,
            RefuelFuelVehicle,
            ChargeElectricVehicle,
            FullDataForOnwerAndVehicle,
        }
    }
}
