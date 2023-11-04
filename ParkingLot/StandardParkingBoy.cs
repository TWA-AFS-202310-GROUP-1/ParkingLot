using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingBoy
    {
        private ParkingLot parkingLot;
        public StandardParkingBoy()
        {
            parkingLot = new ParkingLot();
        }

        public string Park(string car)
        {
            return parkingLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkingLot.FetchCar(ticket);
        }
    }
}
