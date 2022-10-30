using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

          ICustomerRepository repository = new CustomerRepository();

            //SelectAllCustomers(repository);
            GetCustomerById(repository, 3);

        }

        static void SelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void GetCustomerById (ICustomerRepository repository, int id)
        {
            PrintCustomer(repository.GetCustomer(id));
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.Email} ---");
        }


    }
}
