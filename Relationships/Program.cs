using Microsoft.EntityFrameworkCore;
using Relationships.Contexts;

internal class Program
{
    static async Task Main()
    {
        var _dbContext = new AppDbContext();
        
        await _dbContext.Database.MigrateAsync();

        Console.WriteLine("Hello, World!");


    }
}