namespace prjHotelaria.Entities
{
    internal class Reserve
    {
        public string ContractorCPF { get; private set; }
        public string? CompanionCPF { get; private set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Days { get; set; }
        public int RoomNumber { get; set; }
        public double CompTotal { get; private set; }
        public bool CheckIn { get; private set; }
        public bool Breakfast { get; private set; }

        public Reserve(string contractor, DateTime checkin, DateTime checkout, int room, double total, bool isCheckin, bool breakfast)
        {
            ContractorCPF = contractor;
            CheckinDate = checkin;
            CheckoutDate = checkout;
            Breakfast = breakfast;
            Days = (int)(CheckoutDate.Date - CheckinDate.Date).TotalDays;
            RoomNumber = room;
            CheckIn = isCheckin;
        }

        public void CheckCompanion(string cpf) { CompanionCPF = cpf; }

        public double RoomTotal() => (RoomNumber * 100) * Days;
        public double BreakFastTotal() => (CompanionCPF == null) ? Days * 20 : (Days * 20) * 2;
        public double CompanionTotal(DateTime companionDate)
        {
            TimeSpan timeSpan = (DateTime.Now.Date - companionDate);
            bool age = (timeSpan.TotalDays / 365.25) > 18;

            if (!age) return 0;

            CompTotal = (RoomTotal() * 0.50);
            return CompTotal;

        }

        public double Total() => RoomTotal() + (Breakfast ? BreakFastTotal() : 0) + CompTotal;

        public void SetCheckIn(DateTime checkin) { CheckinDate = checkin; }
        public void SetCheckOut(DateTime checkout) { CheckoutDate = checkout; }

        public void RealizeCheckin() { CheckIn = true; }
    }

}
