
﻿using System.ComponentModel.Design;
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

       
        // retirar listas abaixo
        List<Reserve> reservations = new List<Reserve>();
        List<Client> clients = new List<Client>();

        
    }

    private static void SaveClients(List<Client> clients)
    {
        if (clients.Count > 0)
        {
            StreamWriter sw = new StreamWriter("costumers.vsf");

            foreach (Client client in clients)
            {
                sw.WriteLine(client.ToFile());
            }

            sw.Close();
        }
    }

    private static void SaveReservaions(List<Reserve> reservations)
    {
        if (reservations.Count > 0)
        {
            StreamWriter sw = new StreamWriter("reservations.vsf");

            foreach (Reserve reservation in reservations)
            {
                sw.WriteLine(reservation.ToFile());
            }

            sw.Close();
        }
    }

    private static Reserve DoReservation()
    {
        Reserve newReserve;

        DateTime dateCheckin;
        DateTime dateCheckout;
        string cpfCostumer;
        string cpfCompanion;
        string continueReserve;
        string companion;
        string breakfast;
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
        cpfCostumer = Console.ReadLine();

        // verificar se o cliente já tem cadastro

        // verificar se o cliente é maior de idade

        do
        {
            Console.Write("Terá acompanhante? [S/N] ");
            companion = Console.ReadLine().ToUpper();
        } while (companion != "S" && companion != "N");
        Console.WriteLine();

        if (companion == "S")
        {
            Console.Write("Informe o CPF do acompanhante: ");
            cpfCompanion = Console.ReadLine();
            // verificar se o acompanhante já tem cadastro
        }
        else cpfCompanion = "";
        Console.WriteLine();

        do
        {
            Console.Write("Terá café da manhã? [S/N] ");
            breakfast = Console.ReadLine().ToUpper();
        } while (breakfast != "S" && breakfast != "N");

        if (breakfast == "N")
            breakfast = "Não"; // sem cafe
        else
            breakfast = "Sim"; // com cafe
        Console.WriteLine();

        // informar o valor total

        Console.WriteLine("Resumo da reserva: ");
        Console.WriteLine("  Data de check-in: " + dateCheckin);
        Console.WriteLine("  Data de check-out: " + dateCheckout);
        Console.WriteLine("  CPF do cliente: " + cpfCostumer);
        Console.WriteLine("  CPF do acompanhante: " + cpfCompanion);
        Console.WriteLine("  Café da manhã: " + breakfast);
        Console.WriteLine();

        do
        {
            Console.WriteLine("Deseja concluir a reserva? [S/N]");
            continueReserve = Console.ReadLine().ToUpper();
        } while (continueReserve != "S" && continueReserve != "N");

        if (continueReserve == "N")
            return null;

        return new(cpfCostumer, dateCheckin, dateCheckout, 1);
    }

        
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
              Reserve reserva = DoReservation();
              if (reserva == null)
              Console.WriteLine("Reserva não realizada");
              else
              {
                  reservations.Add(reserva);
                  Console.WriteLine("Reserva realizada com SUCESSO!");
              }

              SaveReservaions(reservations);
              SaveClients(clients);
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