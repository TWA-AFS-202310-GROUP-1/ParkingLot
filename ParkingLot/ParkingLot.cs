namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, string> ticketsToCars = new Dictionary<string, string>();

        public string FetchCar(string ticket)
        {
            if (ticket == null)
            {
                return null;
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
                    return null;
                }
            }
        }

        public string Park(string car)
        {
            string ticket = "-" + car;
            ticketsToCars[ticket] = car;
            return ticket;
        }
    }
}
