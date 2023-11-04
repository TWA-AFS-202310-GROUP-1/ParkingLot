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
            return ticketCarPairs[ticket];
        }
        private string GenerateTicket()
        {
            return Guid.NewGuid().ToString();
        }

    }
}

