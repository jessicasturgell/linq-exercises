// Given the collections of items shown below, use LINQ to build the requested collection, and then Console.WriteLine() each item in that resulting collection.

// Find the words in the collection that start with the letter 'L'
List<string> fruits = new List<string>()
{
    "Lemon",
    "Apple",
    "Orange",
    "Lime",
    "Watermelon",
    "Loganberry"
};

IEnumerable<string> LFruits = fruits.Where(f => f.StartsWith("L"));

foreach (var fruit in LFruits)
{
    Console.WriteLine(fruit);
}

// Which of the following numbers are multiples of 4 or 6
List<int> numbers = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);

foreach (var number in fourSixMultiples)
{
    Console.WriteLine(number);
}

// Build a collection of these numbers sorted in ascending order
List<int> ascend = numbers.OrderBy(n => n).ToList();
foreach (int data in ascend)
{
    Console.WriteLine(data);
}

// Output how many numbers are in this list
int numberOfNumbers = numbers.Count();
Console.WriteLine($"There are {numberOfNumbers} numbers in the collection.");

// Order these student names alphabetically, in descending order (Z to A)
List<string> names = new List<string>()
{
    "Heather",
    "James",
    "Xavier",
    "Michelle",
    "Brian",
    "Nina",
    "Kathleen",
    "Sophia",
    "Amir",
    "Douglas",
    "Zarley",
    "Beatrice",
    "Theodora",
    "William",
    "Svetlana",
    "Charisse",
    "Yolanda",
    "Gregorio",
    "Jean-Paul",
    "Evangelina",
    "Viktor",
    "Jacqueline",
    "Francisco",
    "Tre"
};

List<string> descend = names.OrderByDescending(n => n).ToList();
foreach (string data in descend)
{
    Console.WriteLine(data);
}

// How much money have we made?
List<double> purchases = new List<double>()
{
    2340.29,
    745.31,
    21.76,
    34.03,
    4786.45,
    879.45,
    9442.85,
    2454.63,
    45.65
};

double purchasesSum = purchases.Sum();
double sumRounded = Math.Round(purchasesSum, 2);
Console.WriteLine($"We have made ${sumRounded} so far.");

// What is our most expensive product?
List<double> prices = new List<double>()
{
    879.45,
    9442.85,
    2454.63,
    45.65,
    2340.29,
    34.03,
    4786.45,
    745.31,
    21.76
};

double mostExpensive = prices.Max();
Console.WriteLine($"Our most expensive product costs ${mostExpensive}.");

List<int> wheresSquaredo = new List<int>()
{
    66,
    12,
    8,
    27,
    82,
    34,
    7,
    50,
    19,
    46,
    81,
    23,
    30,
    4,
    68,
    14
};

/*
    Store each number in the following List until a perfect square
    is detected.

    Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 }

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/

IEnumerable<int> takeNums = wheresSquaredo.TakeWhile(n => (Math.Sqrt(n) % 1) != 0);
foreach (int num in takeNums)
{
    Console.WriteLine(num);
}
