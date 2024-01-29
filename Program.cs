using System;
using HMSDatabase;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Mysqlx.Crud;



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
                    System.Console.WriteLine("| [3] Add Guest                |");
                    System.Console.WriteLine("| [4] End program              |");
                    System.Console.WriteLine("--------------------------------");
                    System.Console.Write("Choice: ");
                    
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
                            System.Console.WriteLine("");
                            AddGuest();
                            break;
                        case 4:
                            System.Console.WriteLine("Terminating..");
                            isRunning = false;
                            break;
                        default:
                            System.Console.WriteLine("Please choose another option");
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
                
                Console.WriteLine($"Name: {d.Name} | Nationality: {d.Nationality} | Adress: {d.Adress} | DateOfBirth: {d.DateOfBirth} | Phone Number: {d.PhoneNr} ");
                
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
                Console.WriteLine($"Room Number: {room.RoomNr} | Status: {room.RoomStatus} | ViewType: {room.ViewType} | Last Cleaning Date: {room.LastCleaningDate} ");
                
            }
            System.Console.WriteLine("");

        }

        static void AddGuest()
        {
            Console.WriteLine("Add Guest");
            Console.Write("Insert name of the guest: ");
            string guestName = Console.ReadLine();
            Console.Write("Insert Adress of the guest: ");
            string adress = Console.ReadLine();
            Console.Write("Insert Date of birth of the guest (YYYY-MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            HMSDatabase.HMSDatabase.AddGuest(guestName, dateOfBirth, adress);
        }

    }
}
