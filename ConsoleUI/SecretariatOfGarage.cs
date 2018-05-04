using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class SecretariatOfGarage
    {
        private GarageLogic.GarageActs m_Garage;

        public SecretariatOfGarage()
        {
            m_Garage = new GarageLogic.GarageActs();
        }

        public void OpenGarage()
        {
            while (true)
            {
                printMenu();
                doActionInGarage();


            }

        }

        private void doActionInGarage()
        {
            if (Enum.TryParse<eActionFromUser>(Console.ReadLine(), out eActionFromUser actionToDo))
            {
               switch(actionToDo)
                {
                    case eActionFromUser.InsertCarToGarage:
                        createCarAndInsertToGarge();
                        break;
                }
            }
            else
            {
                throw new FormatException();
            }


        }

        private void createCarAndInsertToGarge()
        {
            // todo 
            
        }

        private void printMenu()
        {
            Console.WriteLine(
@"
Menu
==============
1- insert car to garage
2- show list of cars 
3- Change car condition in the garage
4- To fill the vehicle's air dung to the maximum
5- To load energy in the garage
6- View data of car garage
7- Exit");
        }

        public enum eActionFromUser : byte
        {
            InsertCarToGarage = 1,
            ShowListOfCars,
            ChangeCarConditionInTheGarage,
            ToFillTheVehicleWheelsAirToMaximum,
            ToLoadEnergyInVehicle,
            ViewDataOfCarInGarage,
            Exit
        }
    }
}
