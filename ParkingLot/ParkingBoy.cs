using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class ParkingBoy
    {
        private readonly ParkingLot _parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            _parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return _parkingLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return _parkingLot.Fetch(ticket);
        }
    }
}


