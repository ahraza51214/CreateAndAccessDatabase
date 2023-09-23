using System;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories
{
    public class ConnectionStringHelper
    {
        // ConnectionString() method to configure the connection string which connects to the database
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.UserID = "SA";
            connectionStringBuilder.Password = "Ali51214";
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}