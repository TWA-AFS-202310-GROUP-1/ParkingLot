using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StandardParkingBoy
    {
        private Dictionary<string, ParkingLot> id2parkingLot = new Dictionary<string, ParkingLot>();

        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.id2parkingLot.Add("1", parkingLot);
        }

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                this.id2parkingLot.Add((i + 1).ToString(), parkingLots[i]);
            }
        }

        public string Park(string car)
        {
            if (id2parkingLot.Where(x => x.Value.Capacity > 0).ToList().Count == 0)
            {
                throw new NoPositionException("No available position.");
            }
            else
            {
                KeyValuePair<string, ParkingLot> chooseParkingLot = id2parkingLot.First(x => x.Value.Capacity > 0);
                string ticketNo = chooseParkingLot.Value.Park(car);
                return chooseParkingLot.Key + ":" + ticketNo;
            }
        }

        public string Fetch(string ticket)
        {
            string[] ticketInfo = ticket.Split(':');
            return this.id2parkingLot[ticketInfo[0]].Fetch(ticketInfo[1]);
        }
    }
}
