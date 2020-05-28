namespace E_Menu_Personel_App.Interfaces
{
    using Models;

    /// <summary>
    /// Give interface for Dish table 
    /// </summary>
    /// <remarks>
    /// Access to the database Dish table is only allowed by using this methods
    /// </remarks>
    public interface IDishRepository
    {
        /// <summary>
        /// Get all Dishes that consist in the database
        /// </summary>
        /// <returns> Method returns an array of Dishes </returns>
        Dish[] GetDishes();

        /// <summary>
        /// Get Dish by its id
        /// </summary>
        /// <param name="id"> InId of wanted dish, require integer argument </param>
        /// <returns> Returns Dish object </returns>
        Dish GetDish(int id);

        /// <summary>
        /// Get Dish by its name
        /// </summary>
        /// <param name="name"> Name of wanted dish, require string argument </param>
        /// <returns> Returns dish object </returns>
        Dish GetDish(string name);

        /// <summary>
        /// Get all Dishes names that consist in the database
        /// </summary>
        /// <returns> Returns an array of string with dishes names in </returns>
        string[] GetDishNames();

        /// <summary>
        /// Create new Dish entity in database
        /// </summary>
        /// <param name="dish"> Dish object that we want create in database, requires Dish object </param>
        /// <returns> Returns id of created dish </returns>
        int CreateDish(Dish dish);

        /// <summary>
        /// Checks if dish exists in database
        /// </summary>
        /// <param name="dish"> Dish object that we want to check in database, requires Dish object </param>
        /// <returns> Returns id of created dish if exists, if not return -1 </returns>
        int CheckDish(Dish dish);


        /// <summary>
        /// Update existing Dish entity
        /// </summary>
        /// <param name="id"> Id of an artist that we want to update, requires integer argument </param>
        /// <param name="dish"> New Artist object that consist of new data of existing artist, requires Artist object </param>
        void UpdateDish(int id, Dish dish);

        /// <summary>
        /// Delete existing dish
        /// </summary>
        /// <param name="id"> Id of a dish that we want to delete, requires integer argument </param>
        void DeleteDish(int id);
    }
}
