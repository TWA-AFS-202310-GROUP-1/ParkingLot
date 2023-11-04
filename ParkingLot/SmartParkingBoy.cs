using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        private ParkingLot lot1;
        private ParkingLot lot2;
        public SmartParkingBoy(ParkingLot lot1, ParkingLot lot2) : base(lot1, lot2)
        {
            this.lot1 = lot1;
            this.lot2 = lot2;
        }

        public string SmartPark(string car)
        {
            int availableSpots1 = lot1.AvailableSpots();
            int availableSpots2 = lot2.AvailableSpots();

            if (availableSpots1 >= availableSpots2)
            {
                return lot1.Park(car) + "-in-parkingLot1";
            }
            else if (availableSpots2 > availableSpots1)
            {
                return lot2.Park(car) + "-in-parkingLot2";
            }

            return " ";
        }

        public string SmartFetch(string ticket)
        {
            return StandardFetch(ticket);
        }
    }
}
