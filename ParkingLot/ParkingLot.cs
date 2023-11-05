﻿using System.Collections.Generic;
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
                return null;
            }

            var ticket = new Ticket();
            this.carsInPark.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (!this.carsInPark.TryGetValue(ticket, out var car))
            {
                return null;
            }

            this.carsInPark.Remove(ticket);
            return car;
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
    }
}
