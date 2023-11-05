using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public SmartParkingBoy()
        {
            parkingLots.Add(new ParkingLot());
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            int maxAvailableLotNumber = -1;
            int maxAvailablePositions = 0;

            for (int i = 0; i < parkingLots.Count(); i++)
            {
                int leftPositions = parkingLots[i].GetLeftPositions();
                if (leftPositions > maxAvailablePositions)
                {
                    maxAvailableLotNumber = i;
                    maxAvailablePositions = leftPositions;
                }
            }

            if (maxAvailableLotNumber == -1)
            {
                throw new NoPositionException();
            }
            else
            {
                return parkingLots[maxAvailableLotNumber].Park(car);
            }
        }

        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                throw new UnvalidTicketException("Unrecognized parking ticket.");
            }
            else
            {
                for (int i = 0; i < parkingLots.Count; i++)
                {
                    if (parkingLots[i].IsCarParkedHere(ticket))
                    {
                        return parkingLots[i].FetchCar(ticket);
                    }
                }

                throw new UnvalidTicketException();
            }
        }

        public string ShowAllCars()
        {
            return string.Join(" | ", parkingLots.Select(x => x.ShowAllCars()).ToList());
        }
    }
}
