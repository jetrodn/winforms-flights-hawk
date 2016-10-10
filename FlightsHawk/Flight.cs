using System;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace FlightsHawk
{
    public class Flight
    {
        protected string table = "FLIGHTS";
        protected string connectionString =
            "data source = THINKPAD-W540; database = Flights; Integrated Security = SSPI;";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;


        //
        // создать новое подключение к базе данных
        //
        public void OpenSqlConection()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
        }

        //
        // Закрыть соединение с базой данных
        //
        public void CloseSqlConnection()
        {
            connection.Close();
        }

        //
        // Кастомный запрос в базу данных
        //
        public void CustomSqlQuery(string query)
        {
            //Инизиализация подключения к Базе Данных
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();

            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }

        //
        // Метод, позволяющий получить все данные из таблицы
        //
        public SqlDataReader GetAllFlights()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();

            string query = "SELECT * FROM " + table;

            command.CommandText = query;
            dataReader = command.ExecuteReader();
            return dataReader;
        }

        public void DeleteFlight()
        {
            OpenSqlConection();



            CloseSqlConnection();
        }
    }
}