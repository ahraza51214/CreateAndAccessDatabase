using System;
using CreateAndAccessDatabase.AppendixB.Models;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
	public class CustomerRepository : ICustomerRepository
	{
		public CustomerRepository()
		{
		}

        public List<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))//new SqlConnection("Server=localhost;Database=Chinook;User Id=SA;Password=Ali51214;TrustServerCertificate=True;"))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                temp.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                temp.Email = reader.GetString(6);
                                customerList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return customerList;
        }


        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetCustomersByCountry()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetHighestSpenders()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMostPopularGenres(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}