using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FlightsHawk
{
    public class Flight
    {
        private int id;
        private string flight_number;
        private string aircraft;

        private DateTime departure_time;
        private DateTime landing_time;

        private string status;
        private double business_class_price;
        private double first_class_price;
        private double distance;
        private string departure;
        private string destination;
        private int free_seats;
        private string airline;

        protected string table = "FLIGHTS";

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;

        protected string connectionString =
            "data source = THINKPAD-W540; database = Flights; Integrated Security = SSPI;";

        //
        // Конструктор по умолчанию
        //
        public Flight()
        {
            flight_number = "A000";
            aircraft = "B000";
            departure_time = DateTime.Today;
            landing_time = DateTime.Today;
            business_class_price = 120;
            first_class_price = 70;
            distance = 1000.00;
            status = "estimated";
            departure = "Chisinau";
            destination = "Chisinau";
            airline = "AirMoldova";
            free_seats = 1;
        }


        public NameValueCollection GetFlightNVCollection(int id)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();

            string query = "SELECT * FROM Flights WHERE ID = '" + id.ToString() + "';";

            NameValueCollection data = new NameValueCollection();

            command.CommandText = query;
            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    this.id = int.Parse(dataReader[0].ToString());
                    flight_number = dataReader[1].ToString();
                    aircraft = dataReader[2].ToString();
                    departure_time = Convert.ToDateTime(dataReader[3].ToString());
                    landing_time = Convert.ToDateTime(dataReader[4].ToString());
                    status = dataReader[5].ToString();
                    departure = dataReader[6].ToString();
                    destination = dataReader[7].ToString();
                    airline = dataReader[8].ToString();
                    free_seats = int.Parse(dataReader[9].ToString());
                }
            }

            data["id"] = this.id.ToString();
            data["flight_number"] = flight_number;
            data["aircraft"] = aircraft;
            data["departure_time"] = departure_time.ToString();
            data["landing_time"] = landing_time.ToString();
            data["status"] = status;
            data["departure"] = departure;
            data["destination"] = destination;
            data["airline"] = airline;
            data["free_seats"] = free_seats.ToString();

            connection.Close();

            return data;
        }

        public int GetCountAllRows()
        {
            string query = "SELECT COUNT(*) FROM FLIGHTS";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            connection.Open();

            command.CommandText = query;
            dataReader = command.ExecuteReader();
            int count = 0;

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    count = int.Parse(dataReader[0].ToString());
                }
            }

            connection.Close();

            return count;
        }

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
        // Кастомнquый запрос в базу данных
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
    }
}