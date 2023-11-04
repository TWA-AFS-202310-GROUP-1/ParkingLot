using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;
        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return parkingLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkingLot.Fetch(ticket);
        }
    }
}
