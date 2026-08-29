namespace C48_G02_ADV02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The system needs to handle
            //  products,
            //  orders,
            //  notifications,
            //  reports

            //Tomorrow we might
            //  add new product categories,
            //  new discount rules,
            //  new notification channels,
            //  new report formats

            List<Product> catalog = ProductCatalog.Catalog;

            #region Smart Product Search
            //Console.WriteLine("\n--- Electronics ---");
            //Helper.PrintSearchList(ProductSearch.SearchProducts(catalog, ProductSearch.IsElectronics));

            //Console.WriteLine("\n--- Under $50 ---");
            //Helper.PrintSearchList(ProductSearch.SearchProducts(catalog, ProductSearch.IsUnder50));

            ////Console.WriteLine("\n--- In Stock ---");
            ////Helper.PrintSearchList(ProductSearch.SearchProducts(catalog, ProductSearch.IsInStock));

            ////Console.WriteLine("\n--- Clothing And Under $100 ---");
            ////Helper.PrintSearchList(ProductSearch.SearchProducts(catalog, ProductSearch.IsClothingAndUnder100));
            #endregion

            #region Custom Report Generator
            //Console.WriteLine("\n--- Short Report ---");
            //ReportGenerator.PrintReport(catalog, ReportGenerator.ShortReport);

            //Console.WriteLine("\n--- Detailed Report ---");
            //ReportGenerator.PrintReport(catalog, ReportGenerator.DetailedReport);


            //Console.WriteLine("\n--- Summary List ---");
            //Helper.PrintList(ReportGenerator.TransformProducts(catalog, ReportGenerator.SummaryList));

            //Console.WriteLine("\n--- Price Labels ---");
            //Helper.PrintList(ReportGenerator.TransformProducts(catalog, ReportGenerator.PriceLabel));


            //Console.WriteLine("\n--- Low-Stock Alert ---");
            //ReportGenerator.PrintReport(ReportGenerator.FilterProducts(catalog, ReportGenerator.ISLowStock), ReportGenerator.LowStockReport);
            #endregion

        }
    }
}
