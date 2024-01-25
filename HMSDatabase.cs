using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;

namespace HMSDatabase
{
    public static class HMSDatabase
    {
        private static string connectionString = "server=localhost;user=root;database=hms";

        public static List<dynamic> GetAllGuest()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                string sql = "SELECT Guest.id, guest.Name as Name, Guest.Adress as Adress, Guest.Nationality as Nationality, Guest.PhoneNr as PhoneNr FROM guest";
                var allGuest = db.Query<dynamic>(sql).ToList();
                return allGuest;
            }
        }

        public static List<dynamic> GetAvailableRooms()
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Room WHERE RoomStatus = 'Available'"; 
                var availableRooms = db.Query<dynamic>(sql).ToList();
                return availableRooms;
            }
        }
       public static void AddGuest(string guestName, DateTime dateOfBirth, string adress)
        {
            using (IDbConnection db = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO Guest (Name, Adress, DateOfBirth) VALUES (@Name, @Adress, @DateOfBirth)";
                db.Execute(sql, new { Name = guestName, Adress = adress, DateOfBirth = dateOfBirth });
            }
        }




       
    }
}
