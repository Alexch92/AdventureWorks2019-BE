using System.Data;
using System.Data.SqlClient;

namespace AdventureWorks2019BE.Connection
{
    public class BaseConnection
    {
        protected string ConnectionString;
        protected SqlConnection Connection;
        private SqlCommand Command;

        public BaseConnection()
        {
            ConnectionString = "Server = (LocalDB)\\MSSQLLocalDB; Database = Contatti; Trusted_Connection = true; MultipleActiveResultSets = true;";
        }

        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);

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
                Command = new SqlCommand(query, Connection);
                SqlDataAdapter dap = new SqlDataAdapter(Command);
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
