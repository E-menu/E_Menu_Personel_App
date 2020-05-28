namespace E_Menu_Personel_App
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Create AppDbContext for migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns> Returns AppDbContext object </returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmenuPersonelApp;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
