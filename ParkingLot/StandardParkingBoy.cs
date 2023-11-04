using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public StandardParkingBoy()
        {
            parkingLots.Add(new ParkingLot());
        }

        public StandardParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                if (parkingLots[i].IsAnyPositionAvailable())
                {
                    return parkingLots[i].Park(car);
                }
            }

            throw new NoPositionException();
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
