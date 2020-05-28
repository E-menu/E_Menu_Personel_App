namespace E_Menu_Personel_App.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Order
    {
        /// <summary>
        /// Store id of order, primary key
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Store id of a dish, foreign key
        /// </summary>
        [ForeignKey("Standard")]
        public int DishID { set; get; }

        /// <summary>
        /// Store id of a table, foreign key
        /// </summary>
        [ForeignKey("Standard")]
        public int TableID { set; get; }

        /// <summary>
        /// Store timeStamp of order
        /// </summary>
        public string TimeStamp { set; get; }
    }
}
