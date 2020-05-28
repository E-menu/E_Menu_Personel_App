namespace E_Menu_Personel_App.Interfaces
{
    using Models;

    /// <summary>
    /// Give interface for Table table 
    /// </summary>
    /// <remarks>
    /// Access to the database Table table is only allowed by using this methods
    /// </remarks>
    public interface ITableRepository
    {
        /// <summary>
        /// Get all Tables from database
        /// </summary>
        /// <returns> Returns an array of tables </returns>
        Table[] GetTables();

        /// <summary>
        /// Get a Track by its id
        /// </summary>
        /// <param name="id"> Id of wanted Track, requires integer argument </param>
        /// <returns> Returns Track object </returns>
        Table GetTable(int id);

        /// <summary>
        /// Create new Table entity in database
        /// </summary>
        /// <param name="table"> Table object that we wat to create, requires Table object </param>
        /// <returns> Returns id of created Table </returns>
        int CreateTable(Table table);

        /// <summary>
        /// Update an existing Table
        /// </summary>
        /// <param name="id"> Id of a table that we want to update, requires integer argument </param>
        /// <param name="table"> New table object that consist of new table data, requires Table object </param>
        void UpdateTable(int id, Table table);

        /// <summary>
        /// Delete existing table
        /// </summary>
        /// <param name="id"> Id of a table that we want to delete, requires integer argument </param>
        void DeleteTable(int id);

        /// <summary>
        /// Add new dish to table
        /// </summary>
        /// <param name="tableID"> Id of a table that we want to add to, requires integer argument </param>
        /// <param name="dishID"> Id of a dish that we want to add, requires integer argument </param>
        //void AddDishToTable(int tableID, int dishID);

                /// <summary>
        /// Get Dishes that belongs to indicated table
        /// </summary>
        /// <param name="tableID"> ID of table whose dishes we want, requires integer argument </param>
        /// <returns> Returns an array of Dishes </returns>
        //Dish[] GetDishes(int tableID);
    }
}
