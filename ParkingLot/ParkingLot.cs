namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        private string insideCar;
        private string ticket;

        public string GetCar(string ticket)
        {
            if (ticket == this.ticket)
            {
                return insideCar;
            }
            else
            {
                return "wrong ticket";
            }
        }

        public string Park(string car)
        {
            insideCar = car;
            ticket = "q";
            return ticket;
        }
    }
}
