namespace C48_G02_C_05
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Book book = new Book();

            #region q1
            //Console.WriteLine(book.password); // Compile-time error

            //Console.WriteLine("Compile-time error: 'password' is inaccessible due to its protection level");
            //Console.WriteLine("Because the 'password' field is private, it can only be accessed from within the Book class");
            #endregion

            #region q2
            //Console.WriteLine(book.copiesInStock);
            //Console.WriteLine("Because the 'copiesInStock' field is internal, it can be accessed from within the same assembly");
            #endregion

            #region q3
            //book.title = "Clean Code";
            //Console.WriteLine(book.title);
            #endregion

            #region q4
            //book.genre = Genre.Science;
            //Console.WriteLine(book.genre);
            #endregion

            #region q5
            //Console.WriteLine("Fiction => " + (int)Genre.Fiction);
            //Console.WriteLine("NonFiction => " + (int)Genre.NonFiction);
            //Console.WriteLine("Science => " + (int)Genre.Science);
            #endregion

            #region q6
            //int genreNumber = 1;
            //Genre genre = (Genre)genreNumber;
            //Console.WriteLine(genre);
            #endregion

            #region q7
            //Genre genre = Genre.Fiction;
            //string genreName = genre.ToString();
            //Console.WriteLine(genreName);
            #endregion

            #region q8
            //string genreText = "Science";
            //Genre genre = (Genre)Enum.Parse(typeof(Genre), genreText);
            //Console.WriteLine(genre);
            #endregion

            #region q9
            //string genreText = "Mystery";
            //bool tryParseResult = Enum.TryParse(typeof(Genre), genreText, out object res);
            //if (tryParseResult)
            //{
            //    Console.WriteLine(res);
            //}
            //else
            //{
            //    Console.WriteLine("Unknown genre");
            //}
            #endregion
        }

    }
}
