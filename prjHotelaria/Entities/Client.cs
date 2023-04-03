namespace prjHotelaria.Entities
{
    internal class Client : Reserve
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }

        public Client(string name, DateTime birth, string cpf, int room, DateTime checkin, DateTime checkout)
        {
            Name = name;
            BirthDate = birth;
            Age = (int)((DateTime.Now - BirthDate).TotalDays / 365.25);
            Status = true;
        }
        public void ChangeStatus()
        {
            if (Status) Status = false;
            else Status = true;
        }
    }
}
