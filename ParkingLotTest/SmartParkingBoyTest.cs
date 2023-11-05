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
        [Fact]
        public void Should_park_in_first_parking_lot_when_park_given_two_availabl()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);

            string ticket = boy.Park("car1");
            Assert.Equal("1:T-car1", ticket);
        }

        [Fact]
        public void Should_park_in_parking_lot_with_more_positions_when_park_given_two_parkinglots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);

            for (int i = 0; i < 3; i++)
            {
                boy.Park("car" + i.ToString());
            }

            string ticket = boy.Park("newcar");
            Assert.Equal("2:T-newcar", ticket);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_given_ticket_in_two_parkinglots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);

            string ticket1 = boy.Park("car1");
            string ticket2 = boy.Park("car2");

            string car1 = boy.Fetch(ticket1);
            string car2 = boy.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_given_unrecognized_ticket()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);
            string ticket1 = boy.Park("car1");

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => boy.Fetch("2:T-car1"));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_given_used_ticket()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);

            string ticket1 = boy.Park("car1");
            string car1 = boy.Fetch(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => boy.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_park_given_two_parkinglots_fully_occupied()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 0; i < 2; i++)
            {
                parkingLots.Add(new ParkingLot());
            }

            SmartParkingBoy boy = new SmartParkingBoy(parkingLots);

            for (int i = 0; i < 20; i++)
            {
                boy.Park("car" + (i + 1).ToString());
            }

            NoPositionException noPositionException = Assert.Throws<NoPositionException>(() => boy.Park("car21"));
            Assert.Equal("No available position.", noPositionException.Message);
        }
    }
}
