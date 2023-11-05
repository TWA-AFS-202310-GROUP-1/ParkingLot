using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public virtual void CheckPosition(Dictionary<string, ParkingLot> id2parkingLot)
        {
            if (id2parkingLot.Where(x => x.Value.Capacity > 0).ToList().Count == 0)
            {
                throw new NoPositionException("No available position.");
            }
        }

        public string Park(string car, Dictionary<string, ParkingLot> id2parkingLot)
        {
            CheckPosition(id2parkingLot);

            KeyValuePair<string, ParkingLot> chooseParkingLot = id2parkingLot.First(x => x.Value.Capacity > 0);
            string ticketNo = chooseParkingLot.Value.Park(car);
            return chooseParkingLot.Key + ":" + ticketNo;
        }
    }
}
