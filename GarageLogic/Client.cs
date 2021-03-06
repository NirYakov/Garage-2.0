﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public sealed class Client
    {
        private readonly string r_OnwerName, r_PhoneNumber;
        private readonly Vehicle r_Vehicle;
        private eStatusInGarage m_CarStatus = eStatusInGarage.InRepair;

        internal Client(Vehicle m_Vehicle, string i_OnwerName, string i_PhoneNumber)
        {
            r_OnwerName = i_OnwerName;
            r_PhoneNumber = i_PhoneNumber;
            r_Vehicle = m_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eStatusInGarage CarStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }

        public string OnwerName => r_OnwerName;

        public string PhoneNumber => r_PhoneNumber;

        public override string ToString()
        {
            string fullClientDetails = string.Format(
@"Client Details
Name: {0}
Phone number: {1}
Vehicle status: {2}
Vehicle Details
{3}"
, r_OnwerName, r_PhoneNumber, m_CarStatus, Vehicle.ToString());
            return fullClientDetails;
        }

        public enum eStatusInGarage
        {
            InRepair,
            DoneRepair,
            Paid
        }
    }
}
