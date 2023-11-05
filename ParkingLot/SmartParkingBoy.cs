using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        public SmartParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override string Park(string car)
        {
            CheckPosition();
            KeyValuePair<string, ParkingLot> chooseParkingLot = Id2parkingLot.Where(x => x.Value.Capacity > 0).OrderByDescending(x => x.Value.Capacity).First();
            string ticketNo = chooseParkingLot.Value.Park(car);
            return chooseParkingLot.Key + ":" + ticketNo;
        }
    }
}
