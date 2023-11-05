using System.Collections.Generic;
using ParkingLotManagement.Interface;
using ParkingLotManagement.Strategy;

namespace ParkingLotManagement.ParkingBoy
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

        public override string Park(string car)
        {
            IStrategy strategy = new SmartStrategy();
            ParkingLot currentLot = strategy.SearchLot(parkingLots);
            return currentLot.Park(car) + "," + parkingLots.IndexOf(currentLot).ToString();
        }
    }
}
