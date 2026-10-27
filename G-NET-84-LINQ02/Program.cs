using LINQ.Models;
using System.Drawing;
using static LINQ.DataSources.Source;
namespace G_NET_84_LINQ02;

internal class Program
{
    static void Main()
    {
        #region 1. Get top 3 most expensive products
        //var result = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
        #endregion

        #region 2. show page 2 of products, with page size = 5 
        //int pageSize = 5;
        //int pageNumber = 2;
        //var result = ProductList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        #endregion

        #region 3. Take products from the list as long as Their UnitPrice is less than $25(list is ordered by price).
        //var result = ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);
        #endregion

        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        #region 4. Check if ALL products in the "Seafood" category are in stock
        //var result = ProductList.Where(p=>p.Category == "Seafood").All(p => p.UnitsInStock > 0);
        //Console.WriteLine(result);
        #endregion

        #region 5. Check if the ID list contains 9  int[] ids = { 3, 9, 13, 18 };
        //int[] ids = { 3, 9, 13, 18 };
        //var result = ids.Contains(9);
        //Console.WriteLine(result);
        #endregion

        #region 6. Group all products by Category and print each group  with its product count.
        //var result = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() });

        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        #region 7. Group products by Category and project only product names per group
        //var result = ProductList
        //    .GroupBy(p => p.Category)
        //    .Select(g => new { Category = g.Key, ProductNames = g.Select(p => p.ProductName) });

        //foreach (var item in result)
        //{
        //    Console.WriteLine($"************ Category: {item.Category} ************");
        //    foreach (var name in item.ProductNames)
        //    {
        //        Console.WriteLine($"ProductName: {name}");
        //    }
        //    Console.WriteLine("--------------------------");
        //}
        #endregion

        #region 8. Find all categories that have MORE THAN 3 products 
        //var result = ProductList
        //    .GroupBy(p => p.Category)
        //    .Where(p => p.Count() > 3);

        //foreach (var item in result)
        //    Console.WriteLine($"Category: {item.Key}, Count: {item.Count()}");
        #endregion

        #region 9. Using QUERY SYNTAX, group customers by Country, and for  each group select { Country, Count, TotalOrderValue }.
        //var result = from c in CustomerList
        //             group c by c.Country into g
        //             select new
        //             {
        //                 Country = g.Key,
        //                 Count = g.Count(),
        //                 TotalOrderValue = g.SelectMany(p => p.Orders).Sum(t => t.Total)
        //             };

        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        #region 10. Calculate the total number of units in stock across all products 
        //var result = ProductList.Sum(p => p.UnitsInStock);

        //Console.WriteLine(result);
        #endregion

        #region 11. Find the CHEAPEST and MOST EXPENSIVE product prices 
        //var cheapestProduct= ProductList.Min(p => p.UnitPrice);
        //var mostExpensiveProduct= ProductList.Max(p => p.UnitPrice);

        //Console.WriteLine($"Cheapest Product Price: {cheapestProduct}");
        //Console.WriteLine($"Most Expensive Product Price: {mostExpensiveProduct}");
        #endregion

        #region 12. Get a distinct list of all product categories 
        //var result = ProductList.Select(p => p.Category).Distinct();

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 13. find product IDs that are in setA but NOT in setB 
        //int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        //int[] setB = { 3, 6, 9, 12, 15, 13 };

        //var result = setA.Except(setB);

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 14. Find countries that  appear in list1 but NOT in list2  (case -insensitive). 
        //string[] list1 = { "Germany", "France", "UK", "Spain" };
        //string[] list2 = { "france", "SPAIN", "Italy" };

        //var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 15. Build a Dictionary<int, Product> keyed by ProductID. Then retrieve and print the product with ID = 18.
        //var result = ProductList.ToDictionary(p => p.ProductID);

        //Console.WriteLine(result[18]);
        #endregion

        #region 16. Get the first product whose price is greater than $50. 
        //var result = ProductList.First(p => p.UnitPrice > 50);
        //var result2 = ProductList.FirstOrDefault(p => p.UnitPrice > 50);
        //Console.WriteLine(result);
        //Console.WriteLine(result2);
        #endregion

        #region 17. Try to get the first product with a price > $500.  it returns null instead of throwing.
        //var result=ProductList.FirstOrDefault(p => p.UnitPrice > 500);

        //Console.WriteLine(result);
        #endregion

        #region 18. Generate a multiplication table row for 7 
        //var result = Enumerable.Range(1, 12).Select(n => $"{7} x {n} = {7 * n}");

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 19. Generate even numbers between 1 and 30. 
        //var result =Enumerable.Range(1, 30).Where(n => n % 2 == 0);

        //Console.WriteLine(string.Join(", ", result));
        #endregion

        #region 20. Concatenate the first 3 product names with the first  3 customer company names into a single sequence.
        // no company name in the customer class, so I will use CustomerName instead

        //var result = ProductList.Take(3).Select(p => p.ProductName).Concat(CustomerList.Take(3).Select(c => c.CustomerName));

        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion

        #region 21. Pair each product with a customer (by position)  and produce  a string "ProductName sold to CompanyName".
        // no company name in the customer class, so I will use CustomerName instead

        //var result = ProductList.Zip(CustomerList, (p, c) => $"{p.ProductName} sold to {c.CustomerName}");
        //foreach (var item in result)
        //    Console.WriteLine(item);
        #endregion
    }
}
