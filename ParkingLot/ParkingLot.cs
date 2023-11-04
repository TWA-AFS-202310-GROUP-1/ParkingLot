using System.Collections.Generic;
using System;

namespace ParkingLotSystem
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticketCarPairs = new Dictionary<string, string>();

        public string Park(string car)
        {
            string ticket = GenerateTicket();
            ticketCarPairs.Add(ticket, car);
            return ticket;
        }
        public string Fetch(string ticket)
        {
            if(ticketCarPairs.ContainsKey(ticket))
            {
                return ticketCarPairs[ticket];
            }
            return null;
            
        }
        private string GenerateTicket()
        {
            return Guid.NewGuid().ToString();
        }

    }
}

