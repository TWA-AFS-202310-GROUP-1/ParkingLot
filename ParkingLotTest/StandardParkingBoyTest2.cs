using ParkingLotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest2
    {
        [Theory]
        [InlineData("car")]
        public void Should_park_the_car_in_first_lot_if_available(string carName)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(10),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);

            //Then
            Assert.Equal(9, parkingLot[0].GetParkingCapicity());
            Assert.Equal(10, parkingLot[1].GetParkingCapicity());
        }

        [Theory]
        [InlineData("car")]
        public void Should_park_the_car_in_second_lot_when_first_lot_not_available_and_second_available(string carName)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(0),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);

            //Then
            Assert.Equal(0, parkingLot[0].GetParkingCapicity());
            Assert.Equal(9, parkingLot[1].GetParkingCapicity());
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_right_car_when_parked_in_two_parkinglots(string car1Name, string car2Name)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(1),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket1 = parkingBoy.Park(car1Name);
            string ticket2 = parkingBoy.Park(car2Name);
            int capacityParkingLot1 = parkingLot[0].GetParkingCapicity();
            int capacityParkingLot2 = parkingLot[1].GetParkingCapicity();
            string car1 = parkingBoy.Fetch(ticket1);
            string car2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal(0, capacityParkingLot1);
            Assert.Equal(9, capacityParkingLot2);
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
            Assert.Equal(1, parkingLot[0].GetParkingCapicity());
            Assert.Equal(10, parkingLot[1].GetParkingCapicity());
        }

        [Theory]
        [InlineData("wrong")]
        public void Should_get_reminder_when_fetch_car_with_wrong_ticket(string wrongTicket)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(1),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_get_reminder_when_fetch_car_with_used_ticket(string carName)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(1),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);
            string car = parkingBoy.Fetch(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));

            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car1", "car2", "car3")]
        public void Should_get_reminder_when_two_parkinglots_both_unavailable(string car1Name, string car2Name, string car3Name)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(1),
                new ParkingLot(1),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket1 = parkingBoy.Park(car1Name);
            string ticket2 = parkingBoy.Park(car2Name);
            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => parkingBoy.Park(car3Name));

            //Then
            Assert.Equal("No available position.", noPositionException.Message);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_without_ticket()
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
           {
                new ParkingLot(1),
                new ParkingLot(10),
           });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string car = parkingBoy.Fetch(null);

            //Then
            Assert.Null(car);
        }
    }
}
