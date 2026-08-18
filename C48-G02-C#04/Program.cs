namespace C48_G02_C_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1
            //double[] prices = { 25.5, 40, 33.75 };
            //Console.WriteLine(prices[1]);
            #endregion

            #region q2
            //int[,] shelfCopies = { { 3, 5 }, { 1, 4 } };
            //Console.WriteLine(shelfCopies[1,0]);
            #endregion

            #region q3
            //PrintWlcomeMassage();
            #endregion

            #region q4
            //PrintBookTitle("Clean code");
            #endregion

            #region q5
            //int pages = 400;
            //Console.WriteLine("Pages before calling the method:  >> " + pages);
            //AddBonusPages(pages);
            //Console.WriteLine("Pages after calling the method:  >> " + pages);
            //Console.WriteLine("Pages did not change because the passing is passing by value >> value type");
            //Console.WriteLine("The C# will create a copy of the variable and send it to the function and the original variable did not change");
            #endregion

            #region q6
            //double[] prices = { 25.5, 40.0 };
            //Console.WriteLine("Prices before calling the method:  >> " + prices[0]);
            //ApplyDiscount(prices);
            //Console.WriteLine("Prices after calling the method:  >> " + prices[0]);
            //Console.WriteLine("The value changes because arrays are reference types and the passing is passing by value >> Ref type");
            //Console.WriteLine("C# passes a copy of the reference to the array, not a copy of the array itself");
            //Console.WriteLine("Therefore, modifying the array elements inside the method affects the original array");
            #endregion

            #region q7
            //int pages = 400;
            //Console.WriteLine("Pages before calling the method:  >> " + pages);
            //AddBonusPagesByRef(ref pages);
            //Console.WriteLine("Pages after calling the method:  >> " + pages);
            //Console.WriteLine("Pages changed because the passing is passing by ref >> value type");
            //Console.WriteLine("The C# will send the ref of the variable to the function and the original variable will change");
            #endregion

            #region q8
            //double[] prices = { 25.5, 40.0 };
            //ReplaceArray(ref prices);
            //Console.WriteLine(prices.Length);
            #endregion

            #region q9
            //Console.WriteLine("test_1 title: Clean code");
            //double price;
            //TryGetPrice("Clean code", out price);
            //if (price > 0)
            //    Console.WriteLine(price);

            //Console.WriteLine("\ntest_2 title: any");
            //TryGetPrice("any", out price);
            //if (price > 0)
            //    Console.WriteLine(price);
            #endregion

            #region q10
            //PrintBookInfo("Claen code");
            //PrintBookInfo("Claen code",1000);
            #endregion

            #region q11
            //PrintBookInfo(pages: 200, title: "Clean Code");
            #endregion

            #region q12
            //PrintAllTitles();
            //PrintAllTitles("Claen code", "C# Basics", "C# OPP");
            #endregion
        }
        #region q3
        static void PrintWlcomeMassage()
        {
            Console.WriteLine("Welcome to the Library!");
        }
        #endregion

        #region q4
        static void PrintBookTitle(string title)
        {
            Console.WriteLine(title);
        }
        #endregion

        #region q5
        static void AddBonusPages(int pages)
        {
            pages += 50;
        }
        #endregion

        #region q6
        static void ApplyDiscount(double[] prices)
        {
            prices[0] -= 5;
        }
        #endregion

        #region q7
        static void AddBonusPagesByRef(ref int pages)
        {
            pages += 50;
        }
        #endregion

        #region q8
        static void ReplaceArray(ref double[] prices)
        {
            prices = [10.0, 12.5, 15.0];
        }
        #endregion

        #region q9
        static bool TryGetPrice(string title, out double price)
        {
            if (title == "Clean code")
            {
                price = 25.5;
                return true;
            }
            price = 0;
            return false;
        }
        #endregion

        #region q10
        static void PrintBookInfo(string title, int pages = 300)
        {
            Console.WriteLine($"title: {title}, pages: {pages}");
        }
        #endregion

        #region q12
        static void PrintAllTitles(params string[] titles)
        {
            for (int i = 0; i <= titles.Length - 1; i++)
            {
                Console.WriteLine($"Book{i + 1}: {titles[i]}");
            }
        }
        #endregion

    }
}
