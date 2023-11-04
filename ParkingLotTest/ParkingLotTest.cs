namespace ParkingLotTest
{
    using Microsoft.VisualBasic;
    using ParkingLotSystem;
    using System;
    using System.IO;
    using System.Net.Sockets;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_park_car()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_car_given_a_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            string car = parkingLot.Fetch(ticket);
            Assert.Equal("Car1", car);
        }

        [Fact]
        public void Should_return_right_car_when_fetch_two_cars()
        {
            var parkingLot = new ParkingLot();
            var ticket1 = parkingLot.Park("Car1");
            var ticket2 = parkingLot.Park("Car2");
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);
            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }


        [Fact]
        public void Should_return_nothing_when_capacity_is_full()
        {
            var parkingLot = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park("car" + i);
            }
            string ticket = parkingLot.Park("car10");
            Assert.Null(ticket);
        }

        [Fact]
        public void Should_return_null_when_park_given_null()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park(null);
            Assert.Null(ticket);
        }

        [Fact]
        public void Should_return_null_when_park_given_a_parked_car()
        {
            var parkingLot = new ParkingLot();
            var ticket1 = parkingLot.Park("Car1");
            var ticket2 = parkingLot.Park("Car1");
            Assert.Null(ticket2);
        }

        [Fact]
        public void Should_return_correct_message_when_fetch_with_a_wrong_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            var wrongTicket = "wrongticket";
            var exception = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch("wrongticket"));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void FetchCar_ShouldThrowException_WhenTicketHasBeenUsed()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            parkingLot.Fetch(ticket); 
            var exception = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }
    }
}
