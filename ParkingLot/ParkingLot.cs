﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class ParkingLot
    {
        private string car;
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();

        public string Fetch(string ticket)
        {
            return ticket2Car.ContainsKey(ticket) ? ticket2Car[ticket] : string.Empty;
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}
