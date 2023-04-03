namespace prjHotelaria.Entities
{
    internal class Reserve
    {
        public string CPF { get; private set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int RoomNumber { get; set; }
        public double TotalDue { get; private set; }

        public void SetCheckIn(DateTime checkin) { CheckinDate = checkin; }
        public void SetCheckOut(DateTime checkout) { CheckoutDate = checkout; }

    }
}
