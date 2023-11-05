using System.Collections.Generic;
using ParkingLotManagement.Exception;
using ParkingLotManagement.Interface;
using ParkingLotManagement.Strategy;

namespace ParkingLotManagement.ParkingBoy
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot> { };
        private ParkingLot currentLot;
        public StandardParkingBoy(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public virtual string Park(string car)
        {
            IStrategy strategy = new StandardStrategy();
            ParkingLot currentLot = strategy.SearchLot(parkingLots);
            return currentLot.Park(car) + "," + parkingLots.IndexOf(currentLot).ToString();
        }

        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            if (!ticket.Contains(","))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string[] tickets = ticket.Split(',');
            int indexOfLot = int.Parse(tickets[1]);
            return parkingLots[indexOfLot].Fetch(tickets[0]);
        }
    }
}
