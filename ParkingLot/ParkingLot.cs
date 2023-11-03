namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        private string insideCar;
        private string ticket;

        public string Park(string car)
        {
            insideCar = car;
            return "q";
        }
    }
}
