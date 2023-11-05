using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        public void Should_park_in_first_parking_lot_when_park_given_two_availabl()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            StandardParkingBoy boy = new StandardParkingBoy(parkingLots);

            string ticket = boy.Park("car1");
            Assert.Equal("1:T-car1", ticket);
        }
    }
}
