namespace C48_G02_ADV02
{
    internal class Helper
    {
        public static void PrintSearchList(List<Product> products)
        {
            products.ForEach(p => Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})"));
        }

        public static void PrintList (List<string> list)
        {
            list.ForEach(p => Console.WriteLine(p));
        }
    }
}
