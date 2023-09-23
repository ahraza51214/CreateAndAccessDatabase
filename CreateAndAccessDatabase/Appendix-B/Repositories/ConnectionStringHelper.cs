using System;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories
{
    public class ConnectionStringHelper
    {
        // ConnectionString() method to configure the connection string which connects to the database
        /*
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "localhost";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.UserID = "SA";
            connectionStringBuilder.Password = "Ali51214";
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }*/

        // The following is only for Windows, if you have MAC, use the above codes instead, please:
        public static string GetConnectionstring()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"N-DK-01-01-6135\SQLEXPRESS",
                InitialCatalog = "Chinook",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
            return connectionStringBuilder.ConnectionString;
        }
    }
}