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
            Console.WriteLine(k_MenuMsg);
            while (!quit)
            {
                actionToDo = (eGarageAction)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);
                Console.Clear();
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
                    createNewVehicle();
                    break;
                default:
                    Console.WriteLine("worng input , insert again");
                    break;
            }

            Console.WriteLine(option);
            return quit;
        }

        private void createNewVehicle()
        {
            string[] allVehcleTypes = Enum.GetNames(typeof(eVehicleOption));
            byte idx = 0;
            foreach (string vehicleType in allVehcleTypes)
            {
                Console.WriteLine("{0}. {1}", idx++, vehicleType);
            }

           // Vehicle v = Clint.returnFuelCar(); //  nir delete

            Console.WriteLine("Insert your number of choice then press 'enter'");
            

            eVehicleOption vehicleChoise;
            const byte outOfChoiseRange = 200;
            vehicleChoise = (eVehicleOption)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);

            string licenceNum = "123" , modelNum = "456";
            // book question- if vehicleChoise = outOfChoiseRange what happend?
            Console.WriteLine("insert the licence number" );
            licenceNum = Console.ReadLine();
            
            while (r_Garage.IsAlreadyInGarage(licenceNum))
            {
                Console.WriteLine("The car in already in the garge , insert anther licence number .");
                licenceNum = Console.ReadLine();
            }
 
            Console.WriteLine("insert the model of car");
            modelNum = Console.ReadLine(); //book need change to modelName ?
            
            Vehicle newVehicle= VehicleCreator.CreateVehicle(vehicleChoise, licenceNum, modelNum);

            switch (vehicleChoise)
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

            string clientName, clientPhoneNumber;
            Console.WriteLine("insert your name");
            clientName = Console.ReadLine();
            Console.WriteLine("insert your phone number");
            clientPhoneNumber = Console.ReadLine();
            r_Garage.InsertNewClint(new Clint(newVehicle, clientName, clientPhoneNumber));
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
            if (!byte.TryParse(Console.ReadLine() , out byte numOfDoors ) || !(numOfDoors >= 2 && numOfDoors <= 5))
            {
                numOfDoors = 2;
            }

            Console.WriteLine("Now insert your car color (defualt is Gray)");
            Console.WriteLine("Insert your number of choice then press 'enter'"); // to do it in maybe another place the Msg. becuse if commeon.
            
            string[] allCarColors = Enum.GetNames(typeof(Car.eCarColor));
            byte idx = 0;
            foreach (string color in allCarColors)
            {
                Console.WriteLine("{0}. {1}", idx++, color);
            }

            Car.eCarColor chosenColor;
            const byte outOfChoiseRange = 200;
            chosenColor = (Car.eCarColor)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);

            VehicleCreator.CarPropertise(i_Car , numOfDoors , chosenColor);
        }

        void MotorcyclePropertise(Vehicle i_Moto)
        {
            Motorcycle.eTypeOfLicense typeOfLicense;

            Console.WriteLine("Insert plase Engine Capacity between 0 - 7,000 and then press 'enter' (defualt is 500)");
            if (!int.TryParse(Console.ReadLine(), out int engineCapacity) || !(engineCapacity >= 0 && engineCapacity <= 7_000))
            {
                engineCapacity = 500;
            }

            Console.WriteLine("choos type of license   (difult is A)");
            string[] allTypeOfLicense = Enum.GetNames(typeof(Motorcycle.eTypeOfLicense));
            byte idx = 0; // book why not i  (or index)?
            foreach (string typeLicense in allTypeOfLicense)
            {
                Console.WriteLine("{0}. {1}", idx++, typeLicense);
            }

            if (!Enum.TryParse<Motorcycle.eTypeOfLicense>(Console.ReadLine(), out typeOfLicense) || !((byte)typeOfLicense < idx))
            {
                typeOfLicense = Motorcycle.eTypeOfLicense.A;
            }

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
