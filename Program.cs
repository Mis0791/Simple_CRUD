using System;
using DbConnection;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Simple_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            Create();
        }

        public static void Read(){
            List<Dictionary<string, object>> user = DbConnector.Query("SELECT FirstName, LastName, FavoriteNumber FROM users");
            System.Console.WriteLine(user);

                for (int i = 0; i < user.Count; i++){
                    System.Console.WriteLine(user[i]);
                    foreach (string key in user[i].Keys){
                        System.Console.WriteLine($"{key}: {user[i][key]}, ");
                    }
                    System.Console.WriteLine();
                }
        }

        public static void Create(){
            string FirstName = "";
            string LastName = "";
            int FavoriteNumber;

            System.Console.WriteLine("\nPlease enter your First Name");
            FirstName = Console.ReadLine();

            System.Console.WriteLine("\nPlease enter your Last Name");
            LastName = Console.ReadLine();

            System.Console.WriteLine("\nPlease enter your Favorite Number");
            string temp = Console.ReadLine();
            while(!(Int32.TryParse(temp, out FavoriteNumber))){
                System.Console.WriteLine("\nNumbers Only");
                temp = Console.ReadLine();
            }


           DbConnector.Execute($"INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES (\"{FirstName}\", \"{LastName}\", \"{FavoriteNumber}\")");
           Read();
        }
    }
}
