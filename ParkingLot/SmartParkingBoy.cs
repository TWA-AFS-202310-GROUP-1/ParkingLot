using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public SmartParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public override ParkingLot SearchLot()
        {
            return this.parkingLots.FirstOrDefault(pk => pk.GetParkingCapicity() == parkingLots.Max(pk => pk.GetParkingCapicity()));
        }
    }
}
