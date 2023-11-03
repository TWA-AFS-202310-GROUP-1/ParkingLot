using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StandardParkingBoy
    {
        private ParkingLot parkingLot;

        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return this.parkingLot.Park(car);
        }
    }
}
