using System;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;

namespace HMSDatabase
{
    public static class HMSDatabase
    {
        static IDbConnection dbConnection;

        // Connection string to connect to the MySQL database
        static string connectionString = "server=localhost;user=root;database=hms";

        static HMSDatabase()
        {
            // Skapa en enda anslutning vid klassens instansiering
            dbConnection = new MySqlConnection(connectionString);
        }

        public static List<dynamic> GetAllGuest()
        {
            string sql = "SELECT Guest.id, guest.Name as Name, Guest.Adress as Adress, Guest.Nationality as Nationality, Guest.PhoneNr as PhoneNr FROM guest";
            var allGuest = dbConnection.Query<dynamic>(sql).ToList();
            return allGuest;
        }

        public static List<dynamic> GetAvailableRooms()
        {
            string sql = "SELECT * FROM Room WHERE RoomStatus = 'Available'";
            var availableRooms = dbConnection.Query<dynamic>(sql).ToList();
            return availableRooms;
        }

        public static void AddGuest(string guestName, DateTime dateOfBirth, string adress)
        {
            string sql = "INSERT INTO Guest (Name, Adress, DateOfBirth) VALUES (@Name, @Adress, @DateOfBirth)";
            dbConnection.Execute(sql, new { Name = guestName, Adress = adress, DateOfBirth = dateOfBirth });
        }

        

    }
}
