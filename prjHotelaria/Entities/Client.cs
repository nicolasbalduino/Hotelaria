namespace prjHotelaria.Entities
{
    internal class Client : Reserve
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }

        public Client(string name, DateTime birth, string cpf)
        {
            Name = name;
            CPF = cpf;
            BirthDate = birth;
            Status = true;
        }

        public void ChangeStatus(bool status) { Status = status; }

        public bool LegalAge()
        {
            TimeSpan timeSpan = (DateTime.Now.Date - BirthDate.Date);
            return (timeSpan.TotalDays / 365.25) > 18;
        }
    }
}
