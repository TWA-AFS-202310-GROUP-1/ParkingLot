namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public bool IsAnyPositionAvailable()
        {
            if (ticketsToCars.Count < capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCarParkedHere(string ticket)
        {
            if (ticketsToCars.ContainsKey(ticket))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ShowAllCars()
        {
            List<string> list = new List<string>();
            list = ticketsToCars.Select(x => x.Value).ToList();

            return string.Join(" ", list);
        }

        public int GetLeftPositions()
        {
            return capacity - ticketsToCars.Count;
        }
    }
}
