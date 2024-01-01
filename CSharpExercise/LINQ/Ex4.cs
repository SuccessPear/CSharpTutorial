using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace Exercise;
class LinqExercise04
{ 
    public class CustomerInfo
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
    }
    public class BankAccountInfo
    {
        public string BankName { get; set; }
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        public int Deposit { get; set; }
        public int Debt { get; set; }
        public string ClassType { get; set; }
    }
    private static List<BankAccountInfo> bankAccounts;
    private static List<CustomerInfo> customers;
    public static void ParseCustomerInfo()
    {
        string filePath = "D:\\Download\\BKHN\\LearnCode\\Seminar2024\\CSharpTutorial\\CSharpExercise\\LINQ\\data\\CustomerInfo.csv";
        if (File.Exists(filePath))
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Skip header if needed
            var dataRows = lines.Skip(1);

            // Process data using LINQ
            customers = (from line in dataRows
                        let fields = line.Split(',')
                        where fields.Length == 4 // Assuming two columns in this example, to ensure that missing data is removed
                        select new CustomerInfo ()
                        {
                            ID = int.Parse(fields[0]),
                            Name = fields[1],
                            Age = int.Parse(fields[2]),
                            IsMale = fields[3] == "M" ? true: false,
                        }).ToList();
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
    }

    public static void ParseBankInfo()
    {
        string filePath = "D:\\Download\\BKHN\\LearnCode\\Seminar2024\\CSharpTutorial\\CSharpExercise\\LINQ\\data\\BankAccountInfo.csv";
        if (File.Exists(filePath))
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Skip header if needed
            var dataRows = lines.Skip(1);

            // Process data using LINQ
            bankAccounts = (from line in dataRows
                         let fields = line.Split(',')
                         where fields.Length == 6 // Assuming two columns in this example, to ensure that missing data is removed
                         select new BankAccountInfo()
                         {
                             AccountID = int.Parse(fields[0]),
                             BankName = fields[1],
                             CustomerID = int.Parse(fields[2]),
                             Deposit = int.Parse(fields[3]),
                             Debt = int.Parse(fields[4]),
                             ClassType = fields[5],
                         }).ToList();
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
    }

    public static void GetOldestPeople()
    {
        var query = from customer in customers
                    group customer by customer.Age into y
                    orderby y.Key descending
                    select y;

        Console.WriteLine("Oldest people are: \n");
        foreach (var customer in query.FirstOrDefault()) 
        {
            Console.WriteLine("Name: " + customer.Name + "\tID: " + customer.ID + "\n");
        }
    }

    public static void OrderByNameAndIDAscending()
    {
        var query = from customer in customers
                    let name = customer.Name.Split(" ")
                    orderby name.Length > 0 ? name[^1] : string.Empty, customer.ID
                    select customer;

        foreach (var customer in query)
        {
            Console.WriteLine("Name: " + customer.Name + "\tID: " + customer.ID + "\n");
        }
    }

    public static void GetRichestPeople()
    {
        //to be continue
        var queryAccount = from account in bankAccounts
                           group account by account.CustomerID into totalAccount
                           group totalAccount by totalAccount.Sum(x => x.Deposit - x.Debt) into y
                           orderby y.Key descending
                           select y;

        var richestCustomers = queryAccount.FirstOrDefault();
        var queryCustomer = from customer in customers
                            join richestCustomer in richestCustomers on customer.ID equals richestCustomer.CustomerID
                            select customer;


    }
}