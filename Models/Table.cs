namespace E_Menu_Personel_App.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Database model of table
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Store id of table, primary key
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// Store information about table, nullable
        /// </summary>
        public string TableInfo { set; get; } = null;
    }
}
