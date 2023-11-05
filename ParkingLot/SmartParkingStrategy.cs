using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class SmartParkingStrategy : StandardParkingStrategy, IParkingStrategy
    {
        public string Park(string car, Dictionary<string, ParkingLot> id2parkingLot)
        {
            CheckPosition(id2parkingLot);

            KeyValuePair<string, ParkingLot> chooseParkingLot = id2parkingLot.Where(x => x.Value.Capacity > 0).OrderByDescending(x => x.Value.Capacity).First();
            string ticketNo = chooseParkingLot.Value.Park(car);
            return chooseParkingLot.Key + ":" + ticketNo;
        }
    }
}
