using System.Collections.Generic;
using System;

namespace ParkingLotSystem
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private readonly int capacity = 10;
        private Dictionary<string, string> ticketCarPairs = new Dictionary<string, string>();
        private HashSet<string> parkedCars = new HashSet<string>();

        public string Park(string car)
        {
            if(car == null) return null;
            if (ticketCarPairs.Count < capacity && !parkedCars.Contains(car))
            {
                string ticket = GenerateTicket();
                ticketCarPairs.Add(ticket, car);
                parkedCars.Add(car);
                return ticket;
            }
            return null;            
        }
        public string Fetch(string ticket)
        {
            if(ticket !=null && ticketCarPairs.ContainsKey(ticket))
            {
                string car = ticketCarPairs[ticket];
                ticketCarPairs.Remove(ticket);
                parkedCars.Remove(car);
                return car;
            }
            return null;
            
        }
        private string GenerateTicket()
        {
            return Guid.NewGuid().ToString();
        }

    }
}

