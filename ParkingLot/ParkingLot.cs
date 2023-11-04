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
                return "null ticket";
            }
            else
            {
                if (ticketsToCars.ContainsKey(ticket))
                {
                    return ticketsToCars[ticket];
                }
                else
                {
                    return "wrong ticket";
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
