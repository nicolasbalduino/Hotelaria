namespace prjHotelaria.Entities
{
    internal class Companion
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string DependentCPF { get; private set; }
        public bool LegalAge { get; private set; }

        public Companion(string name, DateTime birth, string cpf, int room, DateTime checkin, DateTime checkout, string dependent)
        {
            DependentCPF = dependent;
            SetLegalAge();
        }

        public void SetDependent(string dependent) { DependentCPF = dependent; }
        public void SetLegalAge()
        {
            if (Age < 18) LegalAge = false;
            else LegalAge = true;
        }

        public override string ToString()
        {
            return $"Nome: {Name} | Dependência: {CPF} | Quarto: {RoomNumber} | Data ingresso: {CheckinDate} | Data saida: {CheckoutDate}";
        }

        public string ToFile()
        {
            return $"{Name}|{CPF}|{BirthDate}|{Age}|{RoomNumber}|{DependentCPF}|{CheckinDate}|{CheckoutDate}|{LegalAge}|{Status}";
        }
    }
}
