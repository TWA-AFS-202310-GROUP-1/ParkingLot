using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class ParkingLot
    {
        private string car;
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            if (ticket2car.ContainsKey(ticket))
            {
                return ticket2car[ticket];
            }
            else
            {
                return "no car";
            }
        }

        public string Park(string car)
        {
            this.car = car;
            string ticket = "T-" + car;
            ticket2car.Add(ticket, car);
            return ticket;
        }
    }
}
