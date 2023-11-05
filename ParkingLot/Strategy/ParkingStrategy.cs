using ParkingLotSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Strategy
{
    public interface IParkingStrategy
    {
         string Park(List<ParkingLot> parkingLots, string car);
    }

    public class StandardParkingStrategy : IParkingStrategy
    {
        public string Park(List<ParkingLot> parkingLots, string car)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Park(car);
                }
                catch (NoPositionException)
                {
                    continue;
                }
            }

            throw new NoPositionException("No available position.");
        }
    }

    public class SmartParkingStrategy : IParkingStrategy
    {
        public string Park(List<ParkingLot> parkingLots, string car)
        {
            var parkingLot = parkingLots.OrderByDescending(lot => lot.AvailableCapacity).First();
            return parkingLot.Park(car);
        }
    }
}
