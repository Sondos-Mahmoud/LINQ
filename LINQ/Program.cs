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
            //var Result03 =;

            #endregion


            #region Element Operators


            #endregion


            #region Aggregate Operators

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






            #endregion

            #region Transformation Operators
            /*
            1. Return a sequence of just the names of a list of products.
            2. Produce a sequence of the uppercase and lowercase versions 
            of each word in the original array (Anonymous Types).
            String [] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};
            3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            */
            var Result11 = ProductList.Select(p =>p.ProductName);



            #endregion
        }
    }
}