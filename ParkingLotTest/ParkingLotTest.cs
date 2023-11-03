using Xunit;
using ParkingLotManagement;
using System.Collections.Generic;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        private object tickets;

        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(ticket);

            //Then
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_the_right_car_when_fetch_car_by_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            //When
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            //Then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_by_wrong_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(ticket + "-T");

            //Then
            Assert.Null(car);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_without_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(null);

            //Then
            Assert.Null(car);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_with_used_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(ticket);
            string noCar = parkingLot.Fetch(ticket);
            //Then
            Assert.Equal("car", car);
            Assert.Null(noCar);
        }

        [Fact]
        public void Should_get_null_when_no_parking_lot_left()
        {
            //Given
            int parkingLotCapicity = 20;
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.ParkingCapicity = parkingLotCapicity;
            List<string> tickets = new List<string>();
            for (int i = 0; i < parkingLotCapicity; i++)
            {
                string ticket = parkingLot.Park("car" + i.ToString());
                tickets.Add(ticket);
            }

            //When
            string newTicket = parkingLot.Park("newCar");
            //Then
            for (int i = 0; i < parkingLotCapicity; i++)
            {
                Assert.NotNull(tickets[i]);
            }

            Assert.Null(newTicket);
        }
    }
}
