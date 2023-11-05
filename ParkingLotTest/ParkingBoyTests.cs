using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLot;
using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingBoyTests
    {
        [Fact]
        public void Get_ticket_when_parkingLot_has_capacity_by_parkingBoy()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();

            // When
            var ticket = parkingBoy.ParkCar(car);

            // Then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Get_car_when_fetch_car_with_valid_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var ticket = parkingBoy.ParkCar(car);

            // When
            var fetchedCar = parkingBoy.Fetch(ticket);

            // Then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Get_car_twice_when_fetch_car_with_valid_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingBoy.ParkCar(car1);
            var ticket2 = parkingBoy.ParkCar(car2);

            // When
            var fetchedCar1 = parkingBoy.Fetch(ticket1);
            var fetchedCar2 = parkingBoy.Fetch(ticket2);

            // Then
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Get_exception_when_fetch_car_given_wrong_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            parkingBoy.ParkCar(car);
            var wrongTicket = new Ticket();

            // When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(wrongTicket));

            // Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_fetch_car_given_used_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var ticket = parkingBoy.ParkCar(car);
            parkingBoy.Fetch(ticket);

            // When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(ticket));

            // Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_parkingLot_is_full()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car1 = new Car();
            var car2 = new Car();
            parkingBoy.ParkCar(car1);

            // When
            var exception = Assert.Throws<ParkingLotNoCapacityException>(() => parkingBoy.ParkCar(car2));

            // Then
            Assert.Equal("No capacity for car now.", exception.Message);
        }
    }
}
