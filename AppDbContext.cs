namespace E_Menu_Personel_App
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    /// <summary>
    /// Provides database service
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Create table of tables
        /// </summary>
        public DbSet<Table> Tables { set; get; }

        /// <summary>
        /// Create table of dishes
        /// </summary>
        public DbSet<Dish> Dishes { set; get; }

        /// <summary>
        /// Create table of orders
        /// </summary>
        public DbSet<Order> Orders { set; get; }

        /// <summary>
        /// Constructor of database 
        /// </summary>
        /// <param name="options"> Database options, requires DbContextOptions of AppDbContext object </param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
