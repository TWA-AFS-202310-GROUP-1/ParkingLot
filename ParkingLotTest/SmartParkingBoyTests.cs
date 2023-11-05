using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTests
    {
        [Fact]
        public void Park_car_in_most_capacity_park_when_parkCar_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(2);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            //When
            var ticket = smartParkingBoy.ParkCar(car);

            //Then
            Assert.NotNull(ticket);
            Assert.Equal(1, parkingLot2.AvailableCapacity);
            Assert.Equal(1, parkingLot1.AvailableCapacity);
        }

        [Fact]
        public void Park_car_in_first_park_when_capacity_is_same_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            //When
            var ticket = smartParkingBoy.ParkCar(car);

            //Then
            Assert.NotNull(ticket);
            Assert.Equal(0, parkingLot1.AvailableCapacity);
            Assert.Equal(1, parkingLot2.AvailableCapacity);
        }

        [Fact]
        public void Get_correct_cars_when_fetch_car_with_valid_tickets_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = smartParkingBoy.ParkCar(car1);
            var ticket2 = smartParkingBoy.ParkCar(car2);

            //When
            var fetchedCar1 = smartParkingBoy.Fetch(ticket1);
            var fetchedCar2 = smartParkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Get_exception_when_fetch_car_with_wrong_ticket_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            smartParkingBoy.ParkCar(car);
            var wrongTicket = new Ticket();

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => smartParkingBoy.Fetch(wrongTicket));

            //Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_fetch_car_with_used_ticket_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            var ticket = smartParkingBoy.ParkCar(car);
            smartParkingBoy.Fetch(ticket);

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => smartParkingBoy.Fetch(ticket));

            //Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_parkingLot_is_full_by_smartparkingBoy()
        {
            //Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            smartParkingBoy.ParkCar(car1);
            smartParkingBoy.ParkCar(car2); // This should fill up the parking lots

            //When
            var car3 = new Car();
            var exception = Assert.Throws<ParkingLotNoCapacityException>(() => smartParkingBoy.ParkCar(car3));

            //Then
            Assert.Equal("No capacity for car now.", exception.Message);
        }
    }
}
