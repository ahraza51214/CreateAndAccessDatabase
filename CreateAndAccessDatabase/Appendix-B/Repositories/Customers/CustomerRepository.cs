using System;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using CreateAndAccessDatabase.AppendixB.Models;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
	public class CustomerRepository : ICustomerRepository
	{

        private readonly SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString());


        public List<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (connection)
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
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


        public Customer GetById(int customerId)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @customerId";
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                            customer.Email = reader.GetString(6);
                        }
                    }
                }
            }
            return customer;
        }


        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @name OR LastName LIKE @name";
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                            customer.Email = reader.GetString(6);
                            customerList.Add(customer);
                        }
                    }
                }
            }
            return customerList;
        }


        public List<Customer> GetCustomersByPage(int offset, int limit)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                            "FROM Customer " +
                            "ORDER BY CustomerId " +
                            "OFFSET @offset ROWS " +
                            "FETCH NEXT @limit ROWS ONLY";
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@offset", offset);
                    cmd.Parameters.AddWithValue("@limit", limit);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                            customer.Email = reader.GetString(6);
                            customerList.Add(customer);
                        }
                    }
                }
            }
            return customerList;
        }


        public bool Add(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                            "VALUES (@firstName, @lastName, @country, @postalCode, @phone, @email)";
            using (connection)
            {
                connection.Open();               
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@country", customer.Country);
                    cmd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    success = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            return success;
        }


        public bool Update(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer " +
                            "SET FirstName = @firstName, LastName = @lastName, Country = @country, PostalCode = @postalCode, Phone = @phone, Email = @email " +
                            "WHERE CustomerId = @customerId";
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@country", customer.Country);
                    cmd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);
                    cmd.ExecuteNonQuery();
                }
            }
            return success;
        }


        public bool Delete(int id)
        {
            // Not a requirement to implement for this Assignment.
            throw new NotImplementedException();
        }


        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> customersInCountries = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(*) as Count " +
                         "FROM Customer " +
                         "GROUP BY Country " +
                         "ORDER BY Count DESC";
            using (connection)
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerCountry customerCountry = new CustomerCountry();
                            customerCountry.Country = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
                            customerCountry.CustomersCount = reader.GetInt32(1); 
                            customersInCountries.Add(customerCountry);
                        }
                    }
                }
            }
            return customersInCountries;
        }


        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> highestSpenders = new List<CustomerSpender>();
            string sql = @"SELECT Customer.CustomerId, 
                                  Customer.FirstName + ' ' + Customer.LastName as CustomerName, 
                                  SUM(Invoice.Total) as TotalSpent
                         FROM Customer
                         INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId
                         GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName
                         ORDER BY TotalSpent DESC";
            using (connection)
            {
                connection.Open(); 
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerSpender spender = new CustomerSpender
                            {
                                CustomerId = reader.GetInt32(0),
                                CustomerName = reader.GetString(1),
                                TotalSpent = reader.GetDecimal(2)
                            };
                            highestSpenders.Add(spender);
                        }
                    }
                }
            }
            return highestSpenders;
        }



        public List<string> GetMostPopularGenres(int customerId)
        {
            throw new NotImplementedException();
        }


    }
}