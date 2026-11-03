using G_NET_84_EF01.Contexts;

namespace G_NET_84_EF01;

internal class Program
{
    static void Main(string[] args)
    {
        using var dbContext = new AppDbContext();

        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Connected to the database successfully.");
        }
        else
        {
            Console.WriteLine("Failed to connect to the database.");
        }
    }
}
