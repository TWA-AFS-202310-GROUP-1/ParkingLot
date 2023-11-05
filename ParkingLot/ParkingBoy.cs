using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class ParkingBoy
    {
        private IParkingStrategy strategy;
        private Dictionary<string, ParkingLot> id2parkingLot = new Dictionary<string, ParkingLot>();
        public ParkingBoy(ParkingLot parkingLot, IParkingStrategy strategy)
        {
            this.id2parkingLot.Add("1", parkingLot);
            this.strategy = strategy;
        }

        public ParkingBoy(List<ParkingLot> parkingLots, IParkingStrategy strategy)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                this.id2parkingLot.Add((i + 1).ToString(), parkingLots[i]);
            }

            this.strategy = strategy;
        }

        public string Park(string car)
        {
            return strategy.Park(car, id2parkingLot);
        }

        public string Fetch(string ticket)
        {
            string[] ticketInfo = ticket.Split(':');
            return this.id2parkingLot[ticketInfo[0]].Fetch(ticketInfo[1]);
        }
    }
}
