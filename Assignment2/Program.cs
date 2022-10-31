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

            // SelectAllCustomers(repository);
            //GetCustomerPage(repository, 10, 10 );
            // CustomerFull customer = new CustomerFull() { FirstName="Roberta", LastName="Ramos", Country="England", PostalCode="1234", Phone="123 123 123", Email="email@email.com"};
            // AddCustomer(repository, customer);
            //GetCustomerCountry(repository.GetAllCustomersCountry());
            GetCustomerSpenders(repository.GetAllCustomersSpenders());  

        }
        static void AddCustomer ( ICustomerRepository repository, Customer customer)
        {
            Console.WriteLine(repository.AddCustomer(customer));
        }
        static void GetCustomerPage(ICustomerRepository repository, int offset, int limit)
        {
            PrintCustomers(repository.GetCustomerPage(limit, offset));
        }

       static void GetCustomerSpenders(List<CustomerSpender> spenders)
        {
            foreach (CustomerSpender spender in spenders)
            {
                Console.WriteLine($"{spender.CustomerId} - {spender.FirstName} - {spender.LastName} - {spender.Total}");
            }
        }

        static void GetCustomerCountry(List<CustomerCountry> countries)

        {
            Console.WriteLine("Country \t Amount");
            foreach (CustomerCountry country in countries)
            {
                Console.WriteLine($"{country.Country} \t {country.Amount}");
            }
        }
        static void SelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void GetCustomerById (ICustomerRepository repository, int id)
        {
            PrintCustomer(repository.GetCustomer(id));
        }

        static void GetCustomerByName(ICustomerRepository repository, string firstName)
        {
            PrintCustomer(repository.GetCustomerByName(firstName));
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
            Console.WriteLine($"--- {customer.CustomerId} \t {customer.FirstName}  {customer.LastName}  {customer.Country}  {customer.Email} ---");
        }


    }
}
