namespace C48_G02_C_02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region q1
            //Book book = new Book();
            //Console.WriteLine(book);
            //object bookObj= book;
            //Console.WriteLine(bookObj);
            #endregion

            #region q2
            //Book book = new Book();
            //Console.WriteLine("ToString  =>  "+book.ToString());
            //Console.WriteLine("Equals  =>  "+book.Equals(book));
            //Console.WriteLine("GetHashCode  =>  "+book.GetHashCode());
            //Console.WriteLine("GetType  =>  "+book.GetType());
            #endregion

            #region q3
            //Compile-time error 
            //int pages = 464;
            #endregion

            #region q4
            //int num1 = 10;
            //int num2 = 0;
            //try
            //{
            //    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Cannot divide by zero");
            //}
            //finally { 
            //    Console.WriteLine("Done"); 
            //}
            #endregion

            #region q5
            //int pages = 300;
            //double pagesDouble = pages;
            //Console.WriteLine("pagesDouble => "+ pagesDouble);
            #endregion

            #region q6
            //double price= 49.99;
            //int priceInt= (int)price;
            //Console.WriteLine("priceInt => " + priceInt);
            #endregion

            #region q7
            //string pagesText = "464";
            //int pagesInt = Convert.ToInt32(pagesText);
            //Console.WriteLine(pagesInt);
            #endregion

            #region q8
            //string yearText = "2023";
            //int yearInt = int.Parse(yearText);
            //Console.WriteLine(yearInt);
            ////-------
            //string badText = "abc";
            //bool isParseDone = int.TryParse(badText, out int badTextInt);
            //Console.WriteLine("\n" + badTextInt);
            //if (!isParseDone) Console.WriteLine("Invalid Number");
            #endregion

            #region q9
            //int pages = 464;
            //string pagesString=pages.ToString();
            //Console.WriteLine(pagesString.GetType());
            #endregion

            #region q10
            //int copies = 100;
            //object copiesObj = copies;
            //int copies2 = (int)copiesObj;
            //Console.WriteLine("copiesObj => "+copiesObj);
            //Console.WriteLine("copies2 => "+copies2);
            #endregion

            #region q11
            //int? year = null;
            //Console.WriteLine(year);
            //year = 2023;
            //Console.WriteLine(year);
            #endregion

            #region q12
            //string? reviewer = null;
            //Console.WriteLine(reviewer);
            #endregion

            #region q13
            //Book book = null;
            //Console.WriteLine(book?.title);
            #endregion

        }


    }
}
