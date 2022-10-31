using Assignment2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            bool result = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone,  @Email,)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                  
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        result = cmd.ExecuteNonQuery() > 0 ? true : false;

                    }
                }
            }
            catch (SqlException ex)
            {
                
                Console.WriteLine(ex.Message);
               
            }
            return result;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    Console.WriteLine("Connection open \n");
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
                                if(!reader.IsDBNull(4))
                                    temp.PostalCode = reader.GetString(4);
                                if(!reader.IsDBNull(5))
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customers.Add(temp);


                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public List<CustomerCountry> GetAllCustomersCountry()
        {
            List<CustomerCountry> countries = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(CustomerId) AS Amount FROM Customer "+
                "GROUP BY Country "+
                "ORDER BY Amount DESC, Country ASC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                   
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry temp = new CustomerCountry();
                                temp.Country = reader.GetString(0);
                                temp.Amount = reader.GetInt32(1);
                               
                                countries.Add(temp);


                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return countries;
        }

        public List<CustomerSpender> GetAllCustomersSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();
            string sql = "SELECT Customer.CustomerId, FirstName, LastName, SUM(Total) as Total FROM Customer "+
                "JOIN Invoice "+
                "ON Customer.CustomerId = Invoice.CustomerId "+
                "GROUP BY Customer.CustomerId, FirstName, LastName ORDER BY Total DESC";
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender temp = new CustomerSpender();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Total = reader.GetDecimal(3);
                              
                                spenders.Add(temp);


                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return spenders;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                if (!reader.IsDBNull(4))
                                    customer.PostalCode = reader.GetString(4);
                                if (!reader.IsDBNull(5))
                                    customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                             


                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public Customer GetCustomerByName(string firstName)
        {
            firstName = firstName + "%";
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                "WHERE FirstName LIKE @FirstName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                if (!reader.IsDBNull(4))
                                    customer.PostalCode = reader.GetString(4);
                                if (!reader.IsDBNull(5))
                                    customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);



                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public CustomerGenre GetCustomerGenre(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerPage(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer "+
                "ORDER BY CustomerID OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Limit", limit);
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                if (!reader.IsDBNull(4))
                                    temp.PostalCode = reader.GetString(4);
                                if (!reader.IsDBNull(5))
                                    temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customers.Add(temp);


                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
