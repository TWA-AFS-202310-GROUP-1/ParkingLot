using System.Collections.Generic;
using ParkingLotManagement.Interface;

namespace ParkingLotManagement.Strategy
{
    public class StandardStrategy : IStrategy
    {
        public ParkingLot SearchLot(List<ParkingLot> parkingLots)
        {
            ParkingLot currentLot = parkingLots[parkingLots.Count - 1];
            foreach (var lot in parkingLots)
            {
                if (lot.GetParkingCapicity() > 0)
                {
                    currentLot = lot;
                    break;
                }
            }

            return currentLot;
        }
    }
}
