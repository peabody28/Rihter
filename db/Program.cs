using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace db
{

    static class ORM
    {
        /*
               ExecuteReader ()	Выполняет команды, возвращающие строки.
               
               ExecuteNonQuery ()	Выполняет такие команды, как инструкции SQL INSERT, DELETE и UPDATE.
               
               ExecuteScalar ()	Извлекает одно значение (например, агрегированное значение) из базы данных.
               
        */
        
        static MySqlConnection conn;
        
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
        
        static ORM()
        {
            try
            {
                conn = GetDBConnection("localhost", 3306, "books", "root", "12345678");
                conn.Open();
            }
            catch(MySqlException o)
            {
                Console.WriteLine("Connection Error");
            }
            
        }
        
        public static List<Dictionary<string, string>> Read(string sql)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();

            List<Dictionary<string, string>> array = new List<Dictionary<string, string>>();
            
            while(reader.Read())
            {
                Dictionary<string, string> tmp = new Dictionary<string, string>();
                for (int j = 0; j < 5; j++)
                    tmp.Add(reader.GetName(j), reader.GetValue(j).ToString());
                array.Add(tmp);
            }
            reader.Close();
            return array;
        }

        public static bool Insert(string sql)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                var result = cmd.ExecuteNonQuery();
                return result != 0;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        
        public static bool Delete(Int32 id)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM books_list WHERE id = "+id;
            try
            {
                var result = cmd.ExecuteNonQuery();
                return result != 0;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, string>> array = ORM.Read("SELECT * FROM books_list");
            if (array.Count != 0)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "id", "author", "title", "pages", "price");
                foreach (var val in array)
                {
                    foreach (var v in val)
                        Console.Write(v.Value+"\t");
                    Console.Write("\n");
                }
            }
            else
                Console.WriteLine("table is empty");
            
            bool res = ORM.Insert("INSERT INTO books_list(author, title, pages, price) VALUES ('Max6', 'abcde', 256, 14)");
            if (res)
                Console.WriteLine("row is successfuly added!");
            
            bool res2 = ORM.Delete(4);
            if(res2)
                Console.WriteLine("row is successfuly deleted");
            
            return;         
        }
    }
}