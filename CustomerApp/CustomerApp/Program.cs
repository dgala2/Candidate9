using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public enum Gender
    {
        MALE = 1,
        FEMALE = 2
    }
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - DOB.Year;
            } 
        }
    }

    public class CustomerProcessing : ICustomer
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerProcessing(List<Customer> customerList)
        {
            customers = customerList;
        }
        public double CalculateAverageAgeOfFemales()
        {
            return customers.Where(x => x.Gender == Gender.FEMALE).Select(x => x.Age).Average();
        }

        public double CalculateAverageAgeOfMales()
        {
            return customers.Where(x => x.Gender == Gender.MALE).Select(x => x.Age).Average();
        }

        public double CalculateAverageAge()
        {
            return customers.Select(x => x.Age).Average();
        }

    }
    public interface ICustomer
    {
        double CalculateAverageAge();
        double CalculateAverageAgeOfMales();
        double CalculateAverageAgeOfFemales();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer() { Id = 1, Name = "John", DOB = new DateTime(2000, 10, 4),Gender = Gender.MALE};
            Customer c2 = new Customer() { Id = 2, Name = "Emma", DOB = new DateTime(1999, 5, 1), Gender = Gender.FEMALE };
            Customer c3 = new Customer() { Id = 3, Name = "Mark", DOB = new DateTime(1996, 6, 2), Gender = Gender.MALE };
            List<Customer> custList = new List<Customer>();
            custList.Add(c1);
            custList.Add(c2);
            custList.Add(c3);
            CustomerProcessing cp = new CustomerProcessing(custList);
            Console.WriteLine("Average age of all : " + cp.CalculateAverageAge());
            Console.WriteLine("Average age of males : " + cp.CalculateAverageAgeOfMales());
            Console.WriteLine("Average age of females : " + cp.CalculateAverageAgeOfFemales());
        }
    }
}
