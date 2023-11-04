namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticketsToCars = new Dictionary<string, string>();

        private int capacity = 10;

        public ParkingLot()
        {
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public string FetchCar(string ticket)
        {
            if (ticket == null)
            {
                throw new UnvalidTicketException("Unrecognized parking ticket.");
            }
            else
            {
                if (ticketsToCars.ContainsKey(ticket))
                {
                    string fetchedCar = ticketsToCars[ticket];
                    ticketsToCars.Remove(ticket);
                    return fetchedCar;
                }
                else
                {
                    throw new UnvalidTicketException("Unrecognized parking ticket.");
                }
            }
        }

        public string Park(string car)
        {
            if (ticketsToCars.Count < capacity)
            {
                string ticket = "-" + car;
                ticketsToCars[ticket] = car;
                return ticket;
            }
            else
            {
                throw new NoPositionException("No available position.");
            }
        }
    }
}
