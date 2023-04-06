namespace prjHotelaria.Entities
{
    internal class Reserve
    {
        public string ContractorCPF { get; private set; }
        public Client Companion { get; private set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Days { get; set; }
        public int RoomNumber { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }

        public Reserve(string contractor, DateTime checkin, DateTime checkout, int room)
        {
            ContractorCPF = contractor;
            CheckinDate = checkin;
            CheckoutDate = checkout;
            Days = (int)(CheckoutDate.Date - CheckinDate.Date).TotalDays;
            RoomNumber = room;
        }

        public void CheckCompanion(Client companion) { Companion = companion; }

        public double RoomTotal(double room, bool breakFast)
        {
            Total = room;
            if (Companion.LegalAge()) Total += (room * 0.5);
            if (breakFast) Total += (Days * 20);
            if (Companion != null && breakFast) Total += (Days * 20);

            return Total;
        }

        public void SetCheckIn(DateTime checkin) { CheckinDate = checkin; }
        public void SetCheckOut(DateTime checkout) { CheckoutDate = checkout; }
        public void CalculateDays() { Days = (int)(CheckoutDate.Date - CheckinDate.Date).TotalDays; }

        public void SetStatus(int opt) { Status = opt; }

        public override string ToString()
        {
            return $"CPF Reserva: {ContractorCPF} | Quarto: {RoomNumber}| Checkin: {CheckinDate} | Checkout: {CheckoutDate} | Total: {Total}";
        }

        public string ToFile()
        {
            return $"{ContractorCPF}|{Companion.CPF}|{CheckinDate}|{CheckoutDate}|{RoomNumber}|{Total}|{Status}";
        }
    }

}
