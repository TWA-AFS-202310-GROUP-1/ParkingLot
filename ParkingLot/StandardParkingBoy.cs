using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class StandardParkingBoy
    {
        //private ParkingLot parkingLot;
        private List<ParkingLot> parkingLots = new List<ParkingLot> { };
        private ParkingLot currentLot;
        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public virtual ParkingLot SearchLot()
        {
            ParkingLot currentLot = this.parkingLots[this.parkingLots.Count - 1];
            foreach (var lot in parkingLots)
            {
                if (lot.GetParkingCapicity() > 0)
                {
                    currentLot = lot;
                    break;
                }
            }

            return currentLot;
        }

        public string Park(string car)
        {
            ParkingLot currentLot = SearchLot();
            return currentLot.Park(car) + "," + parkingLots.IndexOf(currentLot).ToString();
        }

        public string? Fetch(string ticket)
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
