using ParkingLotSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    public class SmartParkingBoyMultipleLots
    {
        private readonly List<ParkingLot> _parkingLots;
        public List<ParkingLot> ParkingLots { get => _parkingLots; }

        public SmartParkingBoyMultipleLots(List<ParkingLot> parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            ParkingLot parkingLot = FindLotWithMostPositions();
            return parkingLot.Park(car);
        }

        private ParkingLot FindLotWithMostPositions()
        {
            return _parkingLots.OrderByDescending(lot => lot.AvailableCapacity).First();
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
