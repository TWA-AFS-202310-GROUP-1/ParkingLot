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
        private readonly ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public Ticket ParkCar(Car car)
        {
            return this.parkingLot.ParkCar(car);
        }

        public Car Fetch(Ticket ticket)
        {
            return this.parkingLot.Fetch(ticket);
        }
    }
}