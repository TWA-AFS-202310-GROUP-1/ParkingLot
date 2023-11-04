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

        public void SearchLot()
        {
            foreach (var lot in parkingLots)
            {
                if (lot.GetParkingCapicity() > 0)
                {
                    this.currentLot = lot;
                    return;
                }
            }

            this.currentLot = this.parkingLots[-1];
        }

        public string Park(string car)
        {
            this.SearchLot();
            return currentLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            this.SearchLot();
            return this.currentLot.Fetch(ticket);
        }
    }
}
