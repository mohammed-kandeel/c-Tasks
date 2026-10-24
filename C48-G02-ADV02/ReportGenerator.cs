namespace C48_G02_ADV02
{
    internal class ReportGenerator
    {
        public static void PrintReport<T>(List<T> products, Action<T> reportType) where T : Product
        {
            if (products is not null && reportType is not null)
            {
                products.ForEach(p => reportType(p));
            }
        }
        public static Action<Product> ShortReport = p => Console.WriteLine($"{p.Name} - ${p.Price}");
        public static Action<Product> DetailedReport = p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");
        public static Action<Product> LowStockReport = p => Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");


        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            List<string> result = new();
            if (products is not null && products.Count > 0 && transform is not null)
                foreach (var product in products)
                    result.Add(transform(product));
            return result;
        }
        public static Func<Product, string> SummaryList = p => $"{p.Name} (${p.Price})";
        public static Func<Product, string> PriceLabel = p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}";

        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
        {
            List<Product> result = new();
            if (products is not null && products.Count > 0 && filter is not null)
                foreach (var product in products)
                    if (filter(product))
                        result.Add(product);
            return result;
        }
        public static Predicate<Product> ISLowStock = p => p.Stock < 20;
    }
}
