namespace prjHotelaria.Entities
{
    internal class Client
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }

        public Client(string name, DateTime birth, string cpf)
        {
            Name = name;
            CPF = cpf;
            BirthDate = birth;
        }

        public bool LegalAge()
        {
            TimeSpan timeSpan = (DateTime.Now.Date - BirthDate.Date);
            return (timeSpan.TotalDays / 365.25) > 18;
        }

        public string ToFile()
        {
            return $"{Name}|{CPF}|{BirthDate}";
        }
    }
}
