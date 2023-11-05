using ParkingLotSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class ParkingBoyMultipleLots
    {
        private readonly List<ParkingLot> _parkingLots;
        public List<ParkingLot> ParkingLots { get => _parkingLots; }

        public ParkingBoyMultipleLots(List<ParkingLot> parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            foreach (var parkingLot in _parkingLots)
            {
                try
                {
                    return parkingLot.Park(car);
                }
                catch (Exception ex)
                {
                    if (ex is NoPositionException)
                    {
                        continue;
                    }
                }
            }

            throw new NoPositionException("No available position.");
        }

        public string Fetch(string ticket)
        {
            foreach (var parkingLot in _parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch (Exception ex)
                {
                    if (ex is WrongTicketException)
                    {
                        continue;
                    }
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }
    }
}
