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
        public string? Fetch(string? ticket)
        {
            if (ticket != null && ticket2Car.ContainsKey(ticket))
            {
                return ticket2Car[ticket];
            }
            else
            {
                return null;
            }
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}
