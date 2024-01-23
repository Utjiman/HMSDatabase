using System;
using HMSDatabase;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;



namespace HMSApplication
{
    public class Program{

        static void Main(string[] args)
        {
                bool isRunning = true;
                while(isRunning == true)
                {
                    System.Console.WriteLine("--------------------------------");
                    System.Console.WriteLine("| [1] Show Guests              |");
                    System.Console.WriteLine("| [2] Show available rooms     |");
                    System.Console.WriteLine("| [3] Add something            |");
                    System.Console.WriteLine("| [4] Remove something         |");
                    System.Console.WriteLine("| [5] Avlsuta programmet       |");
                    System.Console.WriteLine("--------------------------------");
                    System.Console.Write("Val: ");
                    
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            System.Console.WriteLine("");
                            PrintAllGuests();
                            break;
                        case 2:
                            System.Console.WriteLine("");
                            ShowAvailableRooms();
                            break;
                        case 3:
                            
                            break;
                        case 4:
                            
                            break;
                        case 5:
                            System.Console.WriteLine("Avslutar..");
                            isRunning = false;
                            break;
                        
                        default:
                            System.Console.WriteLine("Var vänlig välj ett annat alternativ");
                            break;
                    }
                }
            
        }
        static void PrintAllGuests()
        {
            System.Console.WriteLine("-----------");
            System.Console.WriteLine("Show Guest");
            System.Console.WriteLine("-----------");
            
            List<dynamic> Guests = HMSDatabase.HMSDatabase.GetAllGuest();

            
            foreach (dynamic d in Guests)
            {
                
                Console.WriteLine($"Namn: {d.Name} | Nationalitet: {d.Nationality} | Adress: {d.Adress} | DateOfBirth: {d.DateOfBirth} | Phone NR: {d.PhoneNr} ");
                
            }
            System.Console.WriteLine("");
        }
        static void ShowAvailableRooms()
        {
            System.Console.WriteLine("---------------------");
            System.Console.WriteLine("Show available rooms");
            System.Console.WriteLine("---------------------");
            
            List<dynamic> availableRooms = HMSDatabase.HMSDatabase.GetAvailableRooms();
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"Rumnummer: {room.RoomNr} | Status: {room.RoomStatus} | ViewType: {room.ViewType} | Last Cleaning Date: {room.LastCleaningDate} ");
                
            }
            System.Console.WriteLine("");

        }

    }
}
