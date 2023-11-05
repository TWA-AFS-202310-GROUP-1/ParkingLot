using System.Collections.Generic;

namespace ParkingLotManagement.Interface
{
    public interface IStrategy
    {
        ParkingLot SearchLot(List<ParkingLot> parkingLots);
    }
}
