namespace C48_G02_C_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region q1 
            //string title = "clean code";
            //string upperTitle = title.ToUpper();
            //Console.WriteLine($"title      => {title}");
            //Console.WriteLine($"upperTitle => {upperTitle}");
            //Console.WriteLine("\ntitle did not change");
            #endregion

            #region q2
            //string text1 = "Clean Code";
            //string text2 = "Clean Code";

            //bool isSameRef = Object.ReferenceEquals(text1, text2);

            //Console.WriteLine($"text1 => {text1}");
            //Console.WriteLine($"text2 => {text2}");

            //if(isSameRef)
            //    Console.WriteLine("text1 and text2 point to the same object in memory.");
            //else
            //    Console.WriteLine("text1 and text2 point to different objects in memory.");
            #endregion

            #region q3
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Book List");
            //sb.Append(" - Updated");
            //Console.WriteLine(sb);
            #endregion

            #region q4
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Book List");
            //sb.Append(" - Updated");

            //sb.Replace("Book List", "Library");
            //Console.WriteLine(sb);
            #endregion

            #region q5
            //string title = "Clean Code";
            //int pages = 464;

            //string text = "Book: " + title + ", Pages: " + pages;
            //Console.WriteLine(text);

            ////////or
            //Console.WriteLine("Book: " + title + ", Pages: " + pages);
            #endregion

            #region q6
            //string title = "Clean Code";
            //int pages = 464;

            //Console.WriteLine($"Book: {title}, Pages: {pages}");
            #endregion

            #region q7
            //string title = "Clean Code";
            //int pages = 464;

            //string s = string.Format("Book: {0}, Pages: {1}", title, pages);
            //Console.WriteLine(s);
            #endregion

            #region q8
            //int pages = 464;
            //if (pages > 300)
            //    Console.WriteLine("Longe Book");
            //else
            //    Console.WriteLine("Short Book");
            #endregion

            #region q9
            //int pages = 464;
            //bool isAvailable = true;
            //if(pages>300&&isAvailable)
            //    Console.WriteLine("You can borrow this book");
            //else
            //    Console.WriteLine("You can not borrow this book");
            #endregion

            #region q10
            //string title = "Refactodring";
            //switch (title)
            //{
            //    case "Clean Code":
            //        Console.WriteLine("Great choice!");
            //        break;
            //    case "Refactoring":
            //        Console.WriteLine("Nice pick!");
            //        break;
            //    default:
            //        Console.WriteLine("Never heard of it");
            //        break;
            //}
            #endregion

            #region q11
            //int pages = 464;
            //string sizeLabel = pages > 300 ? "Longe Book" : "Short Book";
            //Console.WriteLine(sizeLabel);
            #endregion

            #region q12
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //for (int i = 0; i < books.Length; i++)
            //{
            //    Console.WriteLine($"{i+1}.{books[i]}");   
            //}
            #endregion

            #region q13
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //int i = 0;
            //while (i < books.Length) {
            //        Console.WriteLine($"{i+1}.{books[i]}");
            //    i++;
            //}
            #endregion

            #region q14
            //int i = 0;
            //do
            //{
            //    Console.WriteLine("Checking book...");
            //    i++;
            //}
            //while (i<3);
            #endregion

            #region q15
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //int i = 1;
            //foreach (string book in books) {
            //    Console.WriteLine($"{i}.{book}");
            //    i++;
            //}
            #endregion

            #region q16
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //for (int i = 0; i < books.Length; i++)
            //{
            //    if (books[i] == "Refactoring")
            //        break;

            //    Console.WriteLine($"{i + 1}.{books[i]}");
            //}
            #endregion

            #region q17
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //for (int i = 0; i < books.Length; i++)
            //{
            //    if (books[i] == "The Pragmatic Programmer")
            //        continue;

            //    Console.WriteLine($"{i + 1}.{books[i]}");
            //}
            #endregion

            #region q18
            //string[] books = { "Clean Code", "The Pragmatic Programmer", "Refactoring" };
            //PrintFirstBook(books);

            //Console.WriteLine("\n\ntest Empty Array");
            //string[] emptyBooks = { };
            //PrintFirstBook(emptyBooks);
            #endregion
        }
        static void PrintFirstBook(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("The array is empty.");
                return;
            }
            Console.WriteLine(arr[0]);

        }

    }
}
