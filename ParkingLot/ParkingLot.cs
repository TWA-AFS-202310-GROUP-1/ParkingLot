using System.Collections.Generic;
using System;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<string, string> parkingMap;

        public ParkingLot()
        {
            parkingMap = new Dictionary<string, string>();
        }

        public string ParkCar(string car)
        {
            string ticket = GenerateTicket();
            parkingMap[ticket] = car;
            return ticket;
        }

        public string FetchCar(string ticket)
        {
            if (parkingMap.ContainsKey(ticket))
            {
                string car = parkingMap[ticket];
                parkingMap.Remove(ticket);
                return car;
            }
            else
            {
                return null;
            }
        }

        private string GenerateTicket()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
