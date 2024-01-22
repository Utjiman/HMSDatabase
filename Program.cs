using System;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
class Program{

    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;database=hotel";

        using (IDbConnection db = new MySqlConnection(connectionString))
        {
            var result = db.Query("SELECT * FROM Guest");
            foreach (var row in result)
            {
                Console.WriteLine(row.Name);
            }
        }
    }
    static void PrintAllDogs()
    {
        System.Console.WriteLine("===================");
        System.Console.WriteLine("Print Bookings");
        
        List<dynamic> doglist = DogDatabase.GetAllDogs();

        // Loopa igenom listan
        foreach (dynamic d in doglist)
        {
            // Skriv ut. Notera att egenskaperna (name, race, owner) måste stämma överens med result setet som vi får av dapper i
            // metoden DogDatabase.GetAllDogs()
            Console.WriteLine("Namn: " + d.name + ", ras: " + (string.IsNullOrEmpty(d.race) ? "okänd" : d.race)  + ", ägare:" + d.owner);
        }
    }

}

