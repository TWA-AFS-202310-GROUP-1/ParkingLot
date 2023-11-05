using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLot;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots;

        public ParkingBoy(IEnumerable<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots.ToList();
        }

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots = new List<ParkingLot> { parkingLot };
        }

        public List<ParkingLot> ParkingLots
        {
            get
            {
                return parkingLots;
            }
        }

        protected List<ParkingLot> ParkingLot { get; set; }

        public Ticket ParkCar(Car car)
        {
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.HasAvailablePosition())
                {
                    return parkingLot.ParkCar(car);
                }
            }

            throw new ParkingLotNoCapacityException();
        }

        public Car Fetch(Ticket ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch (InvalidTicketException)
                {
                    // Continue checking the next parking lot
                }
            }

            throw new InvalidTicketException();
        }
    }
}