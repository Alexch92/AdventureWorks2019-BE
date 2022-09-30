using Npgsql;
using System.Data;

namespace AdventureWorks2019BE.Connection
{
    public class NpglBaseConnection
    {

        protected string ConnectionString;
        protected NpgsqlConnection Connection;
        private NpgsqlCommand Command;

        public NpglBaseConnection()
        {
            //jdbc: postgresql://192.0.0.49:5432/sigeo?useUnicode=true&characterEncoding=utf8&useSSL=false&useLegacyDatetimeCode=false&serverTimezone=UTC
            //ConnectionString = "Server=//192.0.0.49:5432/sigeo;Username=alessandro.chiloiro;Database=public;Port=5432;Password=test;SSLMode=false";
            ConnectionString = "Server=192.0.0.49:5432; Port=5432; Database=sigeo; User Id=sigeo; Password=sigeo;";
            //ConnectionString = "User ID=alessandro.chiloiro;Password=test;Host=192.0.0.49:5432/sigeo;Port=5432;Database=public;";
        }

        public void Connect()
        {
            Connection = new NpgsqlConnection(ConnectionString);

            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();
                else
                    throw new Exception("Connection is already Opened");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
                else
                    throw new Exception("Connection is already Closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public DataSet ExecuteQueryForDataSet(string query)
        {
            try
            {
                Connect();

                DataSet ds = new DataSet();
                Command = new NpgsqlCommand(query, Connection);
                NpgsqlDataAdapter dap = new NpgsqlDataAdapter(Command);
                dap.Fill(ds);

                Disconnect();

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }

}
