using System;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories;

public class ConnectionStringHelper
{
	public static string GetConnectionString()
	{
		SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
		connectionStringBuilder.DataSource = "localhost";
		connectionStringBuilder.InitialCatalog = "Chinook";
		connectionStringBuilder.IntegratedSecurity = true;
		connectionStringBuilder.TrustServerCertificate = true;
		return connectionStringBuilder.ConnectionString;
	}
}