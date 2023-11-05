using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLot;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(IEnumerable<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public new Ticket ParkCar(Car car)
        {
            // Order parking lots by the number of available positions in descending order
            var parkingLotWithMostSpace = ParkingLots
                .OrderByDescending(pl => pl.AvailableCapacity)
                .FirstOrDefault();

            if (parkingLotWithMostSpace != null && parkingLotWithMostSpace.HasAvailablePosition())
            {
                return parkingLotWithMostSpace.ParkCar(car);
            }

            throw new ParkingLotNoCapacityException();
        }
    }
}
