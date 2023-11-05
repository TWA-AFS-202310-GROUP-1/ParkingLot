using System.Collections.Generic;
using System.Linq;
using ParkingLotManagement.Interface;

namespace ParkingLotManagement.Strategy
{
    public class SmartStrategy : IStrategy
    {
        public ParkingLot SearchLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.FirstOrDefault(pk => pk.GetParkingCapicity() == parkingLots.Max(pk => pk.GetParkingCapicity()));
        }
    }
}
