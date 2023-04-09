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
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public Room(int room, DateTime checkin, DateTime checkout) { RoomNumber = room; CheckinDate = checkin; CheckoutDate = checkout; }
        public double PerNightValue => Math.Ceiling(RoomNumber/20.0) * 100;
    }
}