﻿using System;
using System.Collections.Generic;

// https://www.dropbox.com/sh/48gs2zvyxmhcg64/AACSRUe6Un4gJYkW01QS2dbpa?dl=0

namespace ConsoleUI
{
    public class Program // book add ref to GarageLogic for checking 
    {
        public static void Main()
        {      
           
            //Testing();
            TestingYosi();

            Console.ReadLine();
            
        }

        public static void TestingYosi()
        {
            try
            {
                GarageLogic.FuelMotorcycle stam = new GarageLogic.FuelMotorcycle("jj", "09", "A1", 300);
                Console.WriteLine(stam.EngineCapacity);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           

           // Console.WriteLine(stam.CarColor);
            Console.ReadLine();
            
        }
    }
}
