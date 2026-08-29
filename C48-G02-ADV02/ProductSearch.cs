namespace C48_G02_ADV02
{
    internal class ProductSearch
    {
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> boolFactory)
        {
            List<Product> result = new();
            if (products is not null && products.Count > 0 && boolFactory is not null)
            {
                foreach (Product item in products)
                    if (boolFactory(item))
                        result.Add(item);
            }
            return result;
        }
        public static Func<Product, bool> IsElectronics = product => product.Category == "Electronics";
        public static Func<Product, bool> IsInStock = product => product.Stock > 0;
        public static Func<Product, bool> IsUnder50 = product => product.Price < 50;
        public static Func<Product, bool> IsClothingAndUnder100 = product => product.Category == "Clothing" && product.Price < 100;
    }
}
