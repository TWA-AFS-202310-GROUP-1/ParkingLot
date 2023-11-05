using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StandardParkingBoy
    {
        public StandardParkingBoy(ParkingLot parkingLot)
        {
            this.Id2parkingLot.Add("1", parkingLot);
        }

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                this.Id2parkingLot.Add((i + 1).ToString(), parkingLots[i]);
            }
        }

        public Dictionary<string, ParkingLot> Id2parkingLot { get; set; } = new Dictionary<string, ParkingLot>();

        public void CheckPosition()
        {
            if (Id2parkingLot.Where(x => x.Value.Capacity > 0).ToList().Count == 0)
            {
                throw new NoPositionException("No available position.");
            }
        }

        public virtual string Park(string car)
        {
            CheckPosition();
            KeyValuePair<string, ParkingLot> chooseParkingLot = Id2parkingLot.First(x => x.Value.Capacity > 0);
            string ticketNo = chooseParkingLot.Value.Park(car);
            return chooseParkingLot.Key + ":" + ticketNo;
        }

        public string Fetch(string ticket)
        {
            string[] ticketInfo = ticket.Split(':');
            return this.Id2parkingLot[ticketInfo[0]].Fetch(ticketInfo[1]);
        }
    }
}
