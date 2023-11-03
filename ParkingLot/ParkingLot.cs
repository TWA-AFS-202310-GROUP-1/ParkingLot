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
            if (ticket == null)
            {
                return null;
            }

            if (ticket2car.ContainsKey(ticket))
            {
                string nowTicket = ticket2car[ticket];
                ticket2car.Remove(ticket);
                return nowTicket;
            }
            else
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }

        public string Park(string car)
        {
            if (ticket2car.Count() < 10)
            {
                this.car = car;
                string ticket = "T-" + car;
                ticket2car.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new WrongTicketException("No available position.");
            }
        }
    }
}
