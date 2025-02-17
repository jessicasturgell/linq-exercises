﻿// Build a collection of customers who are millionaires

/*
    TASK:
    As in the previous exercise, you're going to output the millionaires,
    but you will also display the full name of the bank. You also need
    to sort the millionaires' names, ascending by their LAST name.

    Example output:
        Tina Fey at Citibank
        Joe Landy at Wells Fargo
        Sarah Ng at First Tennessee
        Les Paul at Wells Fargo
        Peg Vale at Bank of America
*/

// Define a bank
public class Bank
{
    public required string Symbol { get; set; }
    public required string Name { get; set; }
}

public class Customer
{
    public required string Name { get; set; }
    public double Balance { get; set; }
    public required string Bank { get; set; }
}

public class BankReport
{
    public required string ReportBank { get; set; }
    public required int ReportMillionaires { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Create some banks and store in a List
        List<Bank> banks = new List<Bank>()
        {
            new Bank() { Name = "First Tennessee", Symbol = "FTB" },
            new Bank() { Name = "Wells Fargo", Symbol = "WF" },
            new Bank() { Name = "Bank of America", Symbol = "BOA" },
            new Bank() { Name = "Citibank", Symbol = "CITI" },
        };

        List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                Name = "Bob Lesman",
                Balance = 80345.66,
                Bank = "FTB"
            },
            new Customer()
            {
                Name = "Joe Landy",
                Balance = 9284756.21,
                Bank = "WF"
            },
            new Customer()
            {
                Name = "Meg Ford",
                Balance = 487233.01,
                Bank = "BOA"
            },
            new Customer()
            {
                Name = "Peg Vale",
                Balance = 7001449.92,
                Bank = "BOA"
            },
            new Customer()
            {
                Name = "Mike Johnson",
                Balance = 790872.12,
                Bank = "WF"
            },
            new Customer()
            {
                Name = "Les Paul",
                Balance = 8374892.54,
                Bank = "WF"
            },
            new Customer()
            {
                Name = "Sid Crosby",
                Balance = 957436.39,
                Bank = "FTB"
            },
            new Customer()
            {
                Name = "Sarah Ng",
                Balance = 56562389.85,
                Bank = "FTB"
            },
            new Customer()
            {
                Name = "Tina Fey",
                Balance = 1000000.00,
                Bank = "CITI"
            },
            new Customer()
            {
                Name = "Sid Brown",
                Balance = 49582.68,
                Bank = "CITI"
            }
        };

        // LINQ
        Console.WriteLine("Millionaires:");
        IEnumerable<Customer> millionaires = customers.Where(c => c.Balance >= 1000000);
        millionaires.ToList().ForEach(m => Console.WriteLine(m.Name));
        Console.WriteLine();

        /*
        Given the same customer set, display how many millionaires per bank.
        Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

        Example Output:
        WF 2
        BOA 1
        FTB 1
        CITI 1
        */

        Console.WriteLine("Millionaires Per Bank:");
        List<BankReport> bankReport = (
            from millionaire in millionaires
            //dealing with kids list
            group millionaire by millionaire.Bank into bankGroup
            //now dealing with neighborhoodGroup list
            select new BankReport
            {
                ReportBank = bankGroup.Key,
                ReportMillionaires = bankGroup.Count()
            }
        ).OrderByDescending(br => br.ReportMillionaires).ToList();

        foreach (BankReport entry in bankReport)
        {
            Console.WriteLine($"{entry.ReportBank} {entry.ReportMillionaires}");
        }

        Console.WriteLine();

        var millionaireReport =
            from millionaire in millionaires
            join bank in banks on millionaire.Bank equals bank.Symbol
            let lastName = millionaire.Name.Split(' ').Last()
            orderby lastName
            select new { MillionaireName = millionaire.Name, BankName = bank.Name };

        Console.WriteLine("Millionaires and Banks:");
        foreach (var report in millionaireReport)
        {
            Console.WriteLine($"{report.MillionaireName} at {report.BankName}");
        }
    }
}

// // Given the collections of items shown below, use LINQ to build the requested collection, and then Console.WriteLine() each item in that resulting collection.

// // Find the words in the collection that start with the letter 'L'
// List<string> fruits = new List<string>()
// {
//     "Lemon",
//     "Apple",
//     "Orange",
//     "Lime",
//     "Watermelon",
//     "Loganberry"
// };

// IEnumerable<string> LFruits = fruits.Where(f => f.StartsWith("L"));

// foreach (var fruit in LFruits)
// {
//     Console.WriteLine(fruit);
// }

// // Which of the following numbers are multiples of 4 or 6
// List<int> numbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

// IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);

// foreach (var number in fourSixMultiples)
// {
//     Console.WriteLine(number);
// }

// // Build a collection of these numbers sorted in ascending order
// List<int> ascend = numbers.OrderBy(n => n).ToList();
// foreach (int data in ascend)
// {
//     Console.WriteLine(data);
// }

// // Output how many numbers are in this list
// int numberOfNumbers = numbers.Count();
// Console.WriteLine($"There are {numberOfNumbers} numbers in the collection.");

// // Order these student names alphabetically, in descending order (Z to A)
// List<string> names = new List<string>()
// {
//     "Heather",
//     "James",
//     "Xavier",
//     "Michelle",
//     "Brian",
//     "Nina",
//     "Kathleen",
//     "Sophia",
//     "Amir",
//     "Douglas",
//     "Zarley",
//     "Beatrice",
//     "Theodora",
//     "William",
//     "Svetlana",
//     "Charisse",
//     "Yolanda",
//     "Gregorio",
//     "Jean-Paul",
//     "Evangelina",
//     "Viktor",
//     "Jacqueline",
//     "Francisco",
//     "Tre"
// };

// List<string> descend = names.OrderByDescending(n => n).ToList();
// foreach (string data in descend)
// {
//     Console.WriteLine(data);
// }

// // How much money have we made?
// List<double> purchases = new List<double>()
// {
//     2340.29,
//     745.31,
//     21.76,
//     34.03,
//     4786.45,
//     879.45,
//     9442.85,
//     2454.63,
//     45.65
// };

// double purchasesSum = purchases.Sum();
// double sumRounded = Math.Round(purchasesSum, 2);
// Console.WriteLine($"We have made ${sumRounded} so far.");

// // What is our most expensive product?
// List<double> prices = new List<double>()
// {
//     879.45,
//     9442.85,
//     2454.63,
//     45.65,
//     2340.29,
//     34.03,
//     4786.45,
//     745.31,
//     21.76
// };

// double mostExpensive = prices.Max();
// Console.WriteLine($"Our most expensive product costs ${mostExpensive}.");

// List<int> wheresSquaredo = new List<int>()
// {
//     66,
//     12,
//     8,
//     27,
//     82,
//     34,
//     7,
//     50,
//     19,
//     46,
//     81,
//     23,
//     30,
//     4,
//     68,
//     14
// };

// /*
//     Store each number in the following List until a perfect square
//     is detected.

//     Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 }

//     Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
// */

// IEnumerable<int> takeNums = wheresSquaredo.TakeWhile(n => (Math.Sqrt(n) % 1) != 0);
// foreach (int num in takeNums)
// {
//     Console.WriteLine(num);
// }
