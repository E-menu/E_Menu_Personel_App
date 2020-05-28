namespace E_Menu_Personel_App.Repositories
{
    using Models;
    using Interfaces;
    using System.Linq; 
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Implementation of methods from IDishRepository
    /// </summary>
    public class DishRepository : IDishRepository
    {
        /// <summary>
        /// Store database context
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor that creates database context
        /// </summary>
        public DishRepository()
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
        public DishRepository(AppDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Get all Dishes that consist in the database
        /// </summary>
        /// <returns> Method returns an array of Dishes </returns>
        public Dish[] GetDishes()
        {
            var dishes = context.Dishes.ToArray();
            return dishes;
        }

        /// <summary>
        /// Get Dish by its id
        /// </summary>
        /// <param name="id"> InId of wanted dish, require integer argument </param>
        /// <returns> Returns Dish object </returns>
        public Dish GetDish(int id)
        {
            var dish = context.Dishes.Find(id);
            return dish;
        }

        /// <summary>
        /// Get Dish by its name
        /// </summary>
        /// <param name="name"> Name of wanted dish, require string argument </param>
        /// <returns> Returns dish object </returns>
        public Dish GetDish(string name)
        {
            var dish = context.Dishes.Where(x => x.Name == name).First();
            return dish;
        }

        /// <summary>
        /// Get all Dishes names that consist in the database
        /// </summary>
        /// <returns> Returns an array of string with dishes names in </returns>
        public string[] GetDishNames()
        {
            var dishes = GetDishes();
            int quantity = dishes.Count();
            string[] names = new string[quantity];


            for (int i = 0; i < quantity; i++)
            {
                names[i] = dishes[i].Name;
            }
            return names;
        }

        /// <summary>
        /// Create new Dish entity in database
        /// </summary>
        /// <param name="dish"> Dish object that we want create in database, requires Dish object </param>
        /// <returns> Returns id of created dish </returns>
        public int CreateDish(Dish dish)
        {
            context.Dishes.Add(dish);
            context.SaveChanges();
            return dish.DishID;
        }

        /// <summary>
        /// Checks if dish exists in database
        /// </summary>
        /// <param name="dish"> Dish object that we want to check in database, requires Dish object </param>
        /// <returns> Returns id of created dish if exists, if not return -1 </returns>
        public int CheckDish(Dish dish)
        {
            if (context.Dishes.Any(x => x.Name == dish.Name))
            {
                return context.Dishes.Where(x => x.Name == dish.Name).First().DishID;
            }
            else return 0;
            
        }

        /// <summary>
        /// Update existing Dish entity
        /// </summary>
        /// <param name="id"> Id of an artist that we want to update, requires integer argument </param>
        /// <param name="dish"> New Artist object that consist of new data of existing artist, requires Artist object </param>
        public void UpdateDish(int id, Dish dish)
        {
            var oldDish = context.Dishes.Find(id);
            oldDish.Name = dish.Name;
            oldDish.DishPrice = dish.DishPrice;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete existing dish
        /// </summary>
        /// <param name="id"> Id of a dish that we want to delete, requires integer argument </param>
        public void DeleteDish(int id)
        {
            var artist = context.Dishes.Find(id);
            context.Dishes.Remove(artist);
            context.SaveChanges();
        }        
    }
}
