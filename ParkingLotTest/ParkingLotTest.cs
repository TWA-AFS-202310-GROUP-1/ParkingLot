using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_given_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.Fetch(ticket);

            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_not_get_a_car_when_fetch_car_given_wrong_ticket_or_without_a_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car2 = parkingLot.Fetch(string.Empty);

            Assert.Equal(string.Empty, car2);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch("WRONG"));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_not_get_a_car_when_fetch_car_given_ticket_already_used()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string car1 = parkingLot.Fetch(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_not_park_car_when_no_position()
        {
            ParkingLot parkingLot = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                string ticket = parkingLot.Park("car" + i.ToString());
            }

            string ticket11 = parkingLot.Park("car11");

            Assert.Equal(string.Empty, ticket11);
        }
    }
}
