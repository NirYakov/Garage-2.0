﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic 
{
    internal class ElectricMotorcycle : Motorcycle
    {
        const float k_MaxHoursBattery = 1.8f;

        public ElectricMotorcycle(string i_Model, string i_LicenseNumber, string i_TypeOfLicense, int i_EngineCapacity)
            : base (i_Model, i_LicenseNumber, i_TypeOfLicense, i_EngineCapacity, new ElectricEngine(k_MaxHoursBattery))
        {
        }
        
    }
}
