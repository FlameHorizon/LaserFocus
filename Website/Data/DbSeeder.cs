using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Entities;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Rides.AnyAsync())
        {
            Console.WriteLine("Table 'Rides' contains data. Not seeding.");
            return;
        }

        var random = new Random();

        var rides = Enumerable.Range(1, 20)
            .Select(i => new Ride
            {
                Name = $"Ride {random.Next(1000, 9999)}"
            });

        db.Rides.AddRange(rides);
        await db.SaveChangesAsync();
    }
}

