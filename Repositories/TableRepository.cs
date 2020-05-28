namespace E_Menu_Personel_App.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Interfaces;
    using System.Linq;

    /// <summary>
    /// Implementation of methods from ITableRepositoty.
    /// </summary>
    public class TableRepository : ITableRepository
    {
        /// <summary>
        /// Store database context
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor that creates database context
        /// </summary>
        public TableRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               //.UseLazyLoadingProxies()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmenuPersonelApp;Trusted_Connection=True;")
               .Options;
            context = new AppDbContext(options);
        }

        /// <summary>
        /// Constructor that assigns existing database context
        /// </summary>
        /// <param name="_context"> Database context, requires AppDbContext object </param>
        public TableRepository(AppDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Get all Tables from database
        /// </summary>
        /// <returns> Returns an array of tables </returns>
        public Table[] GetTables()
        {
            var tables = context.Tables.ToArray();
            return tables;
        }

        /// <summary>
        /// Get a Track by its id
        /// </summary>
        /// <param name="id"> Id of wanted Track, requires integer argument </param>
        /// <returns> Returns Track object </returns>
        public Table GetTable(int id)
        {
            var table = context.Tables.Find(id);
            return table;
        }

        /// <summary>
        /// Create new Table entity in database
        /// </summary>
        /// <param name="table"> Table object that we wat to create, requires Table object </param>
        /// <returns> Returns id of created Table </returns>
        public int CreateTable(Table table)
        {
            context.Tables.Add(table);
            context.SaveChanges();
            return table.TableID;
        }

        /// <summary>
        /// Update an existing Table
        /// </summary>
        /// <param name="id"> Id of a table that we want to update, requires integer argument </param>
        /// <param name="table"> New table object that consist of new table data, requires Table object </param>
        public void UpdateTable(int id, Table table)
        {
            var oldtable = context.Tables.Find(id);
            oldtable.TableInfo = table.TableInfo;
            oldtable.TableID = table.TableID;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete existing table
        /// </summary>
        /// <param name="id"> Id of a table that we want to delete, requires integer argument </param>
        public void DeleteTable(int id)
        {
            var table = context.Tables.Find(id);
            context.Tables.Remove(table);
            context.SaveChanges();
        }
        /// <summary>
        /// Add new dish to table
        /// </summary>
        /// <param name="tableID"> Id of a table that we want to add to, requires integer argument </param>
        /// <param name="dishID"> Id of a dish that we want to add, requires integer argument </param>
        //public void AddDishToTable(int tableID, int dishID)
        //{
        //    var table = context.Tables.Find(tableID);
        //    Dish dish = new Dish();
        //    dish.DishID = dishID;
        //    table.Dish.Add(dish);
        //    context.SaveChanges();
        //}

        /// <summary>
        /// Get Dishes that belongs to indicated table
        /// </summary>
        /// <param name="tableID"> ID of table whose dishes we want, requires integer argument </param>
        /// <returns> Returns an array of Dishes </returns>
        //public Dish[] GetDishes(int tableID)
        //{        
        //    var table = GetTable(tableID);
        //    var dishes = table.Dish.ToArray<Dish>();
        //    return dishes;
        //}
    }
}
