using System.ComponentModel.Design;
using prjHotelaria;
using prjHotelaria.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Client> clientList = new List<Client>();
        List<Reserve> reserveList = new List<Reserve>();
        List<Reserve> reserveListCheckIn = new List<Reserve>();
        List<Room> roomList = new List<Room>();

        ReadFileClient(clientList);
        ReadFileReserve(reserveList, reserveListCheckIn, roomList);

        Menu(clientList, reserveList, reserveListCheckIn, roomList);
    }

    private static void Menu(List<Client> clientList, List<Reserve> reserveList, List<Reserve> reserveListCheckIn, List<Room> roomList)
    {
        int choice;

        do
        {
            Console.WriteLine("Escolha uma operacao:");
            Console.WriteLine("1- Reservar cliente");
            Console.WriteLine("2- Fazer check-in");
            Console.WriteLine("3- Listar reservas");
            Console.WriteLine("4- Listar check-ins");
            Console.WriteLine("0- Sair");

            if(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("digite um numero");
                continue;
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(2000);
                    break;

                case 1:
                    //Funcao de reserva
                    break;

                case 2:
                    //Funcao de check-in
                    break;

                case 3:
                    //Funcao de listagem de reserva
                    break;

                case 4:
                    //Funcao de listagem de check-ins
                    break;
            }

        } while (choice!=0);
    }
    private static void ReadFileClient(List<Client> clientList)
    {
        try
        {
            if (File.Exists("Client.txt"))
            {
                StreamReader sr = new StreamReader("Client.txt");
                do
                {
                    var aux = sr.ReadLine().Split("|");
                    clientList.Add(new Client(aux[0], DateTime.Parse(aux[2]), aux[1]));
                    
                } while (sr.EndOfStream);
            }
            else
            {
                Console.WriteLine("Sem clientes cadastrados");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("houve um problema na leitura do arquivo");
            Thread.Sleep(5000);
            System.Environment.Exit(0);
        }
    }
    private static void ReadFileReserve(List<Reserve> reserveList, List<Reserve> reserveListCheckIn, List<Room> roomList)
    {
        try
        {
            if (File.Exists("Reserve.txt"))
            {
                StreamReader sr = new StreamReader("Reserve.txt");
                do
                {
                    var aux = sr.ReadLine().Split("|");
                    if (int.Parse(aux[6]) == 1)
                    {
                        reserveList.Add(new Reserve(aux[0], DateTime.Parse(aux[2]), DateTime.Parse(aux[3]), int.Parse(aux[4])));
                    }
                    else
                    {
                        reserveListCheckIn.Add(new Reserve(aux[0], DateTime.Parse(aux[2]), DateTime.Parse(aux[3]), int.Parse(aux[4])));
                    }

                    roomList.Add(new Room(int.Parse(aux[4]), DateTime.Parse(aux[2]), DateTime.Parse(aux[3])));
                } while (sr.EndOfStream);
            }
            else
            {
                Console.WriteLine("Sem reservas");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("houve um problema na leitura do arquivo");
            Thread.Sleep(5000);
            System.Environment.Exit(0);
        }
    }

}