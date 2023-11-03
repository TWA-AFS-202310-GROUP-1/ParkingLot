using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            return ticket2Car[ticket];
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}
