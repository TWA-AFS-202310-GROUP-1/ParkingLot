using System.Collections.Generic;
using System;
using System.Runtime.ConstrainedExecution;

namespace ParkingLot
{
    public class ParkingLot
    {
        private readonly int capacity;
        private readonly Dictionary<Ticket, Car> carsInPark;

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            this.carsInPark = new Dictionary<Ticket, Car>();
        }

        public Ticket ParkCar(Car car)
        {
            if (this.carsInPark.Count >= this.capacity || car == null)
            {
                throw new ParkingLotNoCapacityException();
            }

            var ticket = new Ticket();
            this.carsInPark.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (!this.carsInPark.TryGetValue(ticket, out var car))
            {
                throw new InvalidTicketException();
            }

            this.carsInPark.Remove(ticket);
            return car;
        }

        public bool HasAvailablePosition()
        {
            return this.carsInPark.Count < this.capacity;
        }

        public class Car
        {
        }

        public class Ticket
        {
            public Ticket()
            {
                Id = Guid.NewGuid();
            }

            public Guid Id { get; private set; }
        }

        public class ParkingLotNoCapacityException : Exception
        {
            public ParkingLotNoCapacityException() : base("No capacity for car now.")
            {
            }
        }

        public class InvalidTicketException : Exception
        {
            public InvalidTicketException() : base("Invalid parking ticket.")
            {
            }
        }
    }
}
