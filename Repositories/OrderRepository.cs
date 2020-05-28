namespace E_Menu_Personel_App.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Interfaces;
    using System.Linq;

    /// <summary>
    /// Implementation of methods from ITableRepositoty.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Store database context
        /// </summary>
        private readonly AppDbContext context;

        /// <summary>
        /// Constructor that creates database context
        /// </summary>
        public OrderRepository()
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
        public OrderRepository(AppDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Get all Orders that consist in the database
        /// </summary>
        /// <returns> Method returns an array of Orders </returns>
        public Order[] GetOrders()
        {
            var orders = context.Orders.ToArray();
            return orders;
        }

        /// <summary>
        /// Get Order by its id
        /// </summary>
        /// <param name="id"> Id of wanted Order, require integer argument </param>
        /// <returns> Returns Order object </returns>
        public Order GetOrder(int id)
        {
            var order = context.Orders.Find(id);
            return order;
        }

        /// <summary>
        /// Create new Order entity in database
        /// </summary>
        /// <param name="order"> Order object that we want create in database, requires Order object </param>
        /// <returns> Returns id of created Order </returns>
        public int CreateOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order.OrderID;
        }

        /// <summary>
        /// Update existing Order entity
        /// </summary>
        /// <param name="id"> Id of an Order that we want to update, requires integer argument </param>
        /// <param name="order"> New Order object that consist of new data of existing artist, requires Order object </param>
        public void UpdateOrder(int id, Order order)
        {
            var oldOrder = context.Orders.Find(id);
            oldOrder.DishID = order.DishID;
            oldOrder.TableID = order.TableID;
            oldOrder.TimeStamp = order.TimeStamp;
            context.SaveChanges();
        }

        /// <summary>
        /// Delete existing order
        /// </summary>
        /// <param name="id"> Id of a Order that we want to delete, requires integer argument </param>
        public void DeleteOrder(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        /// <summary>
        /// Get all Dishes for table
        /// </summary>
        /// <param name="tableId"> Id of table, which dishes we want, require integer argument </param>
        /// <returns> Returns array of dishes </returns>
        public int[] GetDishes(int tableId)
        {
            Order[] orders = context.Orders.Where(x => x.TableID == tableId).ToArray();
            int[] dishes = new int[orders.Length];
            int i = 0;
            foreach (var x in orders)
            {                
                dishes[i] = orders[i].DishID;
                i++;
            }
            return dishes;
        }
    }
}
