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
        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<CustomerSpender> GetAllCustomersSpenders()
        {
            throw new NotImplementedException();
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

        public Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public CustomerGenre GetCustomerGenre(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerPage(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
