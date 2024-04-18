using Microsoft.EntityFrameworkCore;
using TruckAPI.Models;

namespace TruckAPI.Data
{
    //Used to create an instance to the DB in use, MySQL
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Truck> Trucks { get; set; }

    }
}
