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

            Assert.Equal("1:T-car1", ticket);
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

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => boy.Fetch("1:WRONG"));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_car_given_used_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);
            string ticket1 = boy.Park("car1");
            string car1 = boy.Fetch(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => boy.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_park_car_given_no_position()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);

            for (int i = 0; i < 10; i++)
            {
                string ticket = boy.Park("car" + i.ToString());
            }

            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => boy.Park("car11"));
            Assert.Equal("No available position.", noPositionException.Message);
        }

        [Fact]
        public void Should_park_in_first_parking_lot_when_park_given_two_available()
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

        [Fact]
        public void Should_park_in_second_parking_lot_when_park_given_first_has_no_position()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            StandardParkingBoy boy = new StandardParkingBoy(parkingLots);

            for (int i = 0; i < 10; i++)
            {
                boy.Park("car" + i.ToString());
            }

            string ticket = boy.Park("car1");
            Assert.Equal("2:T-car1", ticket);
        }
    }
}
