namespace Day5
{
    public class ParkingBoy
    {
        private ParkingLot parkinglot;

        public ParkingBoy()
        {
            parkinglot = new ParkingLot();
        }

        public string FetchByParkingBoy(string ticket)
        {
            return parkinglot.Fetch(ticket);
        }

        public string ParkByParkingBoy(string car)
        {
            return parkinglot.Park(car);
        }
    }
}