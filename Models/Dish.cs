namespace E_Menu_Personel_App.Models
{
    /// <summary>
    /// Database model of track
    /// </summary>
    public class Dish
    {
        /// <summary>
        /// Store Id of a dish, primary key
        /// </summary>
        public int DishID { get; set; }

        /// <summary>
        /// Store name of a dish
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Store price of dish
        /// </summary>
        public int DishPrice { get; set; }
    }
}
