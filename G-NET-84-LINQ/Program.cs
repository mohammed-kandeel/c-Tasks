using static LINQ.DataSources.Source;
namespace G_NET_84_LINQ;

internal class Program
{
    static void Main()
    {
        #region 1 - Get all products from the "Seafood" category. Print each product's name and price 
        var result = ProductList.Where(p => p.Category == "Seafood").Select(p => new { name = p.ProductName, price = p.UnitPrice });
        #endregion

        #region 2 - Get a list of only the product names from ProductList. Print each name
        //var result = ProductList.Select(p => p.ProductName);
        #endregion

        #region 3 -  Sort all products by UnitPrice (ascending). Print each product's name and price
        //var result = ProductList.OrderBy(p => p.UnitPrice).Select(p => new { name = p.ProductName, price = p.UnitPrice });
        #endregion

        #region 4 - Get all products where UnitPrice is between 10 and 30
        //var result = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
        #endregion

        #region 5 - Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
        //var result = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
        #endregion

        #region 6 - Create a new anonymous type with three properties:
        /*
        - Name → the product name 
        - Price → the unit price 
        - StockStatus → a string: "Available" if UnitsInStock > 0, otherwise "Out of Stock" 
        - Print the result. 
         */

        //var result = ProductList.Select(p => new
        //{
        //    Name = p.ProductName,
        //    Price = p.UnitPrice,
        //    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        //});

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 7 - Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.
        //var result = ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
        #endregion

        #region 8 -  Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending. 
        //var result = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
        #endregion

        #region 9 -  Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock. 
        //var result=ProductList
        //    .Where(p=>p.Category== "Beverages")
        //    .OrderByDescending(p => p.UnitsInStock)
        //    .Select(p => new { name = p.ProductName, stock = p.UnitsInStock });
        #endregion

        #region 10 - Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate.
        //var result=from c in CustomerList
        //           from o in c.Orders
        //           where o.OrderDate.Year >= 1997
        //           select new { c.CustomerID, o.OrderDate };
        #endregion

        #region 11 - Show position number alongside ProductName 
        //var result = ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
        #endregion

        #region 12 - Sort first by-word length and then by a case -insensitive sort of the words in an array. 
        //String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        //var result = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase).ToArray();
        #endregion

        #region 13 - Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
        //var s = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        //var result = s.Where(w => w[1]=='i').Reverse();
        #endregion

        foreach (var item in result)
            Console.WriteLine(item);
    }
}