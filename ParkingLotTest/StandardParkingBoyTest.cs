using Day5;
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
        [Fact]
        public void Should_get_a_ticket_when_park_given_car()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);

            string ticket = boy.Park("car1");

            Assert.Equal("T-car1", ticket);
        }

        [Fact]
        public void Should_get_a_car_when_fetch_given_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);
            string ticket = boy.Park("car1");

            string car = boy.Fetch(ticket);

            Assert.Equal("car1", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);
            string ticket1 = boy.Park("car1");
            string ticket2 = boy.Park("car2");

            string car1 = boy.Fetch(ticket1);
            string car2 = boy.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_car_given_wrong_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);
            string ticket1 = boy.Park("car1");

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => boy.Fetch("WRONG"));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }
    }
}
