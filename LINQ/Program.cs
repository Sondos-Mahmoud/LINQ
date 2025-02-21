using System.Threading;
using static Demo.ListGenerator;
namespace LINQ
  
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restriction Operators
            /*
             1. Find all products that are out of stock.
             2. Find all products that are in stock and cost more than 3.00 per unit.
             3. Returns digits whose name is shorter than their value.
            */
            var Result01 = ProductList.Where(p => p.UnitsInStock == 0);
            var Result02 = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);


            String[] Arr00 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var Result03 = Arr00.Where((digit, index) => digit.Length < index);

            //var Result03 =;

            #endregion


            #region Element Operators
            /*
             1. Get first Product out of Stock 
             2. Return the first product whose Price > 1000, 
            unless there is no match, in which case null is returned.
             3. Retrieve the second number greater than 5 
             */

            var firstOutOfStockProduct = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            var expensiveProduct = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            int[] Arr05 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNumberGreaterThanFive = Arr05.Where(n => n > 5).Skip(1).FirstOrDefault();


            #endregion


            #region Aggregate Operators
            /*
            1. Uses Count to get the number of odd numbers in the array
            Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            2. Return a list of customers and how many orders each has.
            3. Return a list of categories and how many products each has
            4. Get the total of the numbers in an array.
            Int [] Arr = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0}; 

            5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            9. Get the total units in stock for each product category.
            10. Get the cheapest price among each category's products
            11. Get the products with the cheapest price in each category (Use Let)
            12. Get the most expensive price among each category's products.
            13. Get the products with the most expensive price in each category.
            14. Get the average price of each category's products.
            */
            int[] Arr06={ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var oddCount = Arr06.Count(n => n % 2 != 0);
            var customerOrderCounts = CustomerList  .Select(c => new { c.CustomerID, OrderCount = c.Orders.Count() });
            var categoryProductCounts = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, ProductCount = g.Count() });
          int[] Arr09={ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var totalSum = Arr09.Sum();
            string[] words = File.ReadAllLines("dictionary_english.txt");
            var totalCharacters = words.Sum(w => w.Length);
            var shortestWordLength = words.Min(w => w.Length);
            var longestWordLength = words.Max(w => w.Length);
            var averageWordLength = words.Average(w => w.Length);
            var categoryStockTotals = ProductList.GroupBy(p => p.Category) .Select(g => new { Category = g.Key, TotalStock = g.Sum(p => p.UnitsInStock) });

            var cheapestPriceByCategory = ProductList .GroupBy(p => p.Category) .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            var mostExpensivePriceByCategory = ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });
            var mostExpensiveProductsByCategory = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MostExpensiveProducts = g.Where(p => p.UnitPrice == g.Max(p2 => p2.UnitPrice)).ToList()
                });


            #endregion


            #region  Ordering Operators
            /*
             1. Sort a list of products by name
             2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            */
            var Result04 = ProductList.OrderBy(p => p.ProductName);
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result05 = Arr.OrderBy(A => A, StringComparer.OrdinalIgnoreCase); ;

            /*
             3. Sort a list of products by units in stock from highest to lowest.
             4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
             */
            var Result06 = ProductList.OrderByDescending(p => p.UnitsInStock);

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result07 = digits.OrderBy(d => d.ToString().Length).ThenBy(d => d);

            //5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            string[] Arr01 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }; ;
            var result08 = Arr01.OrderBy(A => A.Length).ThenBy(A => A, StringComparer.OrdinalIgnoreCase);
            //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var result09 = ProductList.OrderByDescending(P => P.Category).ThenByDescending(P => P.UnitPrice);
            //7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            String[] Arr02 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var Result10 = Arr02
                .OrderBy(A => A.Length).ThenByDescending(A => A, StringComparer.OrdinalIgnoreCase);
            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr03 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var Result15 = Arr03.Where(d => d.Length > 1 && d[1] == 'i').Reverse();




            #endregion

            #region Transformation Operators
            /*
            1. Return a sequence of just the names of a list of products.
            2. Produce a sequence of the uppercase and lowercase versions 
            of each word in the original array (Anonymous Types).
            String [] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};
            3. Produce a sequence containing some properties of Products,
            including UnitPrice which is renamed to Price in the resulting type.
            */
            var Result11 = ProductList.Select(p =>p.ProductName);
            String[] words01={ "aPPLE", "BlUeBeRrY", "cHeRry" };
            var Result12 = words01.Select(w => new
            {
                Uppercase = w.ToUpper(),
                Lowercase = w.ToLower()
            });
            var Result13 = ProductList.Select(p => new
            {
                p.ProductID,
                p.ProductName,
                Price = p.UnitPrice // Rename UnitPrice to Price
            });
            //4. Determine if the value of int in an array matches their position in the array.
            int[] Arr14 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Result14 = Arr14.Select((value, index) => value == index);

            /*
            6. Select all orders where the order total is less than 500.00.
            7. Select all orders where the order was made in 1998 or later.
            */
            var Result16 = CustomerList.SelectMany(c => c.Orders)
                                       .Where(o => o.Total < 500);

            var Result17 = CustomerList.SelectMany(c => c.Orders)
                                       .Where(o => o.OrderDate.Year >= 1998);

            #endregion
        }
    }
}