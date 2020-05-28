namespace E_Menu_Personel_App.Interfaces
{
    using Models;
    /// <summary>
    /// Give interface for Order table 
    /// </summary>
    /// <remarks>
    /// Access to the database Order table is only allowed by using this methods
    /// </remarks>
    public interface IOrderRepository
    {
        /// <summary>
        /// Get all Orders that consist in the database
        /// </summary>
        /// <returns> Method returns an array of Orders </returns>
        Order[] GetOrders();

        /// <summary>
        /// Get Order by its id
        /// </summary>
        /// <param name="id"> Id of wanted Order, require integer argument </param>
        /// <returns> Returns Order object </returns>
        Order GetOrder(int id);      

        /// <summary>
        /// Create new Order entity in database
        /// </summary>
        /// <param name="order"> Order object that we want create in database, requires Order object </param>
        /// <returns> Returns id of created Order </returns>
        int CreateOrder(Order order);

        /// <summary>
        /// Update existing Order entity
        /// </summary>
        /// <param name="id"> Id of an Order that we want to update, requires integer argument </param>
        /// <param name="order"> New Order object that consist of new data of existing artist, requires Order object </param>
        void UpdateOrder(int id, Order order);

        /// <summary>
        /// Delete existing order
        /// </summary>
        /// <param name="id"> Id of a Order that we want to delete, requires integer argument </param>
        void DeleteOrder(int id);

        /// <summary>
        /// Get all Dishes for table
        /// </summary>
        /// <param name="tableId"> Id of table, which dishes we want, require integer argument </param>
        /// <returns> Returns array of dishes </returns>
        int[] GetDishes(int tableId);
    }
}
