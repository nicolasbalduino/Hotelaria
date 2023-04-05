using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjHotelaria.Entities
{
    internal class Room
    {
        public int RoomNumber { get; private set; }
        public Room(int room) { RoomNumber = room; }
        public double PerNightValue => (Math.Floor(RoomNumber/20.0) + 1) * 100;
    }
}
