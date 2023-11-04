using Xunit;
using ParkingLotManagement;
using System.Collections.Generic;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        private object tickets;

        [Theory]
        [InlineData("car")]
        public void Should_get_the_same_car_when_fetch_car_by_ticket(string carName)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();

            //When
            string ticket = parkingLot.Park(carName);
            string car = parkingLot.Fetch(ticket);

            //Then
            Assert.Equal("car", car);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_the_right_car_when_fetch_car_by_ticket(string carName1, string carName2)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();

            //When
            string ticket1 = parkingLot.Park(carName1);
            string ticket2 = parkingLot.Park(carName2);
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            //Then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Theory]
        [InlineData("wrong")]
        public void Should_get_reminder_when_fetch_car_by_wrong_ticket(string wrongTicket)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();

            //When
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongTicket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_without_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();

            //When
            string car = parkingLot.Fetch(null);

            //Then
            Assert.Null(car);
        }

        [Theory]
        [InlineData("car")]
        public void Should_get_reminder_when_fetch_car_with_used_ticket(string carName)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();

            //When
            string ticket = parkingLot.Park(carName);
            string car = parkingLot.Fetch(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_get_null_when_no_parking_lot_left()
        {
            //Given
            int parkingLotCapacity = 20;
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.ParkingCapicity = parkingLotCapacity;

            //When
            List<string> tickets = new List<string>();
            for (int i = 0; i < parkingLotCapacity; i++)
            {
                string ticket = parkingLot.Park("car" + i.ToString());
                tickets.Add(ticket);
            }

            string newTicket = parkingLot.Park("newCar");

            //Then
            for (int i = 0; i < parkingLotCapacity; i++)
            {
                Assert.NotNull(tickets[i]);
            }

            Assert.Null(newTicket);
        }
    }
}
