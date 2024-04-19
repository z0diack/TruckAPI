using Microsoft.EntityFrameworkCore;
using TruckAPI.Models;

namespace TruckAPI.Data
{
    //Used to create an instance to the DB in use, MySQL
    public class DataContext : DbContext
    {
        // To be used in program.cs to initialise a connection to our SQL server.
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

    }
}
