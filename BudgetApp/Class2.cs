using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace BudgetApp
{
    internal class ExpensesDAO //Data Access Object
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=expenses;";
        public List<Expenses> getAllExpenses()
        {
            List<Expenses> returnThese = new List<Expenses>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT ID, VALUE, DATE, CATEGORY, DESCRIPTION FROM EXPENSES",connection );
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Expenses a = new Expenses
                    {
                        ID = reader.GetInt32(0),
                        Value = reader.GetFloat(1),
                        Date = reader.GetDateTime(2),
                        Category = reader.GetString(3),
                        Description = reader.GetString(4),
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }
        public List<Expenses> SearchDate(string UMonth, string UYear)
        {
            List<Expenses> returnThese = new List<Expenses>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT ID, VALUE, DATE, CATEGORY, DESCRIPTION FROM EXPENSES WHERE DATE BETWEEN '"+UYear+"-"+UMonth+"-01' AND '"+UYear+"-"+UMonth+"-31'";
            command.Connection = connection;


            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Expenses a = new Expenses
                    {
                        ID = reader.GetInt32(0),
                        Value = reader.GetFloat(1),
                        Date = reader.GetDateTime(2),
                        Category = reader.GetString(3),
                        Description = reader.GetString(4),
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();
            return returnThese;
        }

        internal int addOneAlbum(Expenses expense)
        {
            List<Expenses> returnThese = new List<Expenses>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO EXPENSES (VALUE, DATE, CATEGORY, DESCRIPTION) VALUES (@value, @date, @category, @description)";
            command.Connection = connection;
            command.Parameters.AddWithValue("value",expense.Value);
            command.Parameters.AddWithValue("date", expense.Date);
            command.Parameters.AddWithValue("category", expense.Category);
            command.Parameters.AddWithValue("description", expense.Description);

            int newRows = command.ExecuteNonQuery();
            connection.Close();
            return newRows;
        }
    }
}
