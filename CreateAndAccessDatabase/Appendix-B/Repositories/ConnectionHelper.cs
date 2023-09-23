using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateAndAccessDatabase.Appendix_B.Repositories
{
    public class ConnectionHelper
    {
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
                /*
                connectionStringBuilder.DataSource = @"N-DK-01-01-6135\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true; }
            return connectionStringBuilder.ConnectionString;*/

            /*Scaffold-DbContext "Data Source = N-DK-01-01-6135\SQLEXPRESS;
             Initial Catalog = Chinook; Integrated Security = True;
            Trust Server Certificate = True;" Microsoft.EntityFrameworkCore.SqlServer -o Model

            */
        }
    }
}
