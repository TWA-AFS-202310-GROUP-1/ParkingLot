using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        private int parkCount = 0;
        private List<string> usedTickets = new List<string>();
        private int parkingCapicity = 10;
        private int parkTimes = 0;

        public int ParkingCapicity
        {
            get { return this.parkingCapicity; }
            set { this.parkingCapicity = value; }
        }

        public string? Fetch(string? ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            if (ticket2Car.ContainsKey(ticket) && !usedTickets.Contains(ticket))
            {
                usedTickets.Add(ticket);
                return ticket2Car[ticket];
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }

        public string? Park(string car)
        {
            if (this.parkTimes == parkingCapicity)
            {
                return null;
            }

            parkCount++;
            this.parkTimes++;
            string ticket = "T-" + car + parkCount.ToString();
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}
