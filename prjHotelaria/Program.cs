
using System.ComponentModel.Design;
using prjHotelaria.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Math.Ceiling(1.0));

        List<Reserve> reserves = new List<Reserve>();

        Reserve reserva = DoReservation();
        if (reserva == null)
            Console.WriteLine("Reserva não realizada");
        else
        {
            reserves.Add(reserva);
            Console.WriteLine("Reserva realizada com SUCESSO!");
        }
    }

    private static Reserve DoReservation()
    {
        Reserve newReserve;

        DateTime dateCheckin;
        DateTime dateCheckout;
        string cpfContratante;
        string cpfAcompanhante;
        string continueReserve;
        string acompanhante;
        string cafeManha;
        do
        {
            Console.Write("Informe a data prevista de check-in: ");
            DateTime.TryParse(Console.ReadLine(), out dateCheckin);

            if (dateCheckin < DateTime.Now.Date)
                Console.WriteLine("A data de check-in deve ser maior ou igual que a data de hoje!");

        } while (dateCheckin < DateTime.Now.Date);

        do
        {
            Console.Write("Informe a data prevista de check-out: ");
            DateTime.TryParse(Console.ReadLine(), out dateCheckout);

            if (dateCheckin >= dateCheckout)
                Console.WriteLine("A data de check-out deve ser maior que a data de check-in!");

        } while (dateCheckin >= dateCheckout);

        // verificar se as datas estão livres

        do
        {
            Console.WriteLine("Deseja prosseguir com a reserva? [S/N]");
            continueReserve = Console.ReadLine().ToUpper();
        } while (continueReserve != "S" && continueReserve != "N");

        if (continueReserve == "N")
            return null;

        Console.Write("Informe o CPF do contratante: ");
        cpfContratante = Console.ReadLine();

        // verificar se o cliente já tem cadastro

        // verificar se o cliente é maior de idade

        do
        {
            Console.Write("Terá acompanhante? [S/N] ");
            acompanhante = Console.ReadLine().ToUpper();
        } while (acompanhante != "S" && acompanhante != "N");
        Console.WriteLine();

        if (acompanhante == "S")
        {
            Console.Write("Informe o CPF do acompanhante: ");
            cpfAcompanhante = Console.ReadLine();
            // verificar se o acompanhante já tem cadastro
        }
        else cpfAcompanhante = "";
        Console.WriteLine();

        do
        {
            Console.Write("Terá café da manhã? [S/N] ");
            cafeManha = Console.ReadLine().ToUpper();
        } while (cafeManha != "S" && cafeManha != "N");

        if (cafeManha == "N")
            cafeManha = "Não"; // sem cafe
        else
            cafeManha = "Sim"; // com cafe
        Console.WriteLine();

        // informar o valor total

        Console.WriteLine("Resumo da reserva: ");
        Console.WriteLine("  Data de check-in: " + dateCheckin);
        Console.WriteLine("  Data de check-out: " + dateCheckout);
        Console.WriteLine("  CPF do cliente: " + cpfContratante);
        Console.WriteLine("  CPF do acompanhante: " + cpfAcompanhante);
        Console.WriteLine("  Café da manhã: " + cafeManha);
        Console.WriteLine();

        do
        {
            Console.WriteLine("Deseja concluir a reserva? [S/N]");
            continueReserve = Console.ReadLine().ToUpper();
        } while (continueReserve != "S" && continueReserve != "N");

        if (continueReserve == "N")
            return null;

        return new(cpfContratante, dateCheckin, dateCheckout, 1);
    }
}