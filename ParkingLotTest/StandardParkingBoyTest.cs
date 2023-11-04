using ParkingLotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_get_the_same_car_when_fetch_car_by_ticket(string carName)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);
            string car = parkingBoy.Fetch(ticket);

            //Then
            Assert.Equal("car", car);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_the_right_car_when_fetch_car_by_ticket(string carName1, string carName2)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket1 = parkingBoy.Park(carName1);
            string ticket2 = parkingBoy.Park(carName2);
            string car1 = parkingBoy.Fetch(ticket1);
            string car2 = parkingBoy.Fetch(ticket2);

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
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_without_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string car = parkingBoy.Fetch(null);

            //Then
            Assert.Null(car);
        }

        [Theory]
        [InlineData("car")]
        public void Should_get_reminder_when_fetch_car_with_used_ticket(string carName)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);
            string car = parkingBoy.Fetch(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_get_reminder_when_no_parking_lot_left()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            List<string> tickets = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                string ticket = parkingLot.Park("car" + i.ToString());
                tickets.Add(ticket);
            }

            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => parkingLot.Park("newCar"));

            //Then
            for (int i = 0; i < 10; i++)
            {
                Assert.NotNull(tickets[i]);
            }

            Assert.Equal("No available position.", noPositionException.Message);
        }
    }
}
