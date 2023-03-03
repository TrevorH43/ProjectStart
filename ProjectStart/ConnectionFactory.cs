using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStart
{
    public class ConnectionFactory
    {
        //Current instance of the ConnectionFactory
        private static ConnectionFactory connectionFactory = null;

        //Reference to the app.config connection string configuration
        private static String connectionStringKey = "AdventureWorks2019";


        /// <summary>
        /// Null constructor
        /// </summary>
        private ConnectionFactory()
        {

        }
        public SqlConnection getConnection()
        {
            SqlConnection conn = null;
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            conn = new SqlConnection(connectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
        /// <summary>
        /// Returns an instance of the connection factory
        /// </summary>
        /// <returns></returns>
        public static ConnectionFactory getInstance()
        {
            if (connectionFactory == null)
            {
                connectionFactory = new ConnectionFactory();
            }
            return connectionFactory;
        } 

    }
}
