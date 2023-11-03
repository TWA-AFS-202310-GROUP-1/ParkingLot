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
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        private int capacity = 10;

        public string Fetch(string ticket)
        {
            if (ticket == string.Empty)
            {
                return string.Empty;
            }

            if (!ticket2Car.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket");
            }

            string car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (ticket2Car.Count < 10)
            {
                string ticket = "T-" + car;
                ticket2Car.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new NoPositionException("No available position.");
            }
        }
    }
}
