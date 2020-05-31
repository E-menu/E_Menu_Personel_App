namespace E_Menu_Personel_App
{
    using Models;
    using Interfaces;
    using Repositories;

    using System;
    using System.Windows;
    using Table = Models.Table;

    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();

            ITableRepository repoTable = new TableRepository();
            var tableNames = repoTable.GetTables();            
            string[] tables = new string[tableNames.Length];
            int i = 0;
            foreach (var x in tableNames)
            {                
                tables[i] = tableNames[i].TableID.ToString();
                i++;
            }
            tableSelect.ItemsSource = tables;
            IDishRepository repoDish = new DishRepository();
            string[] dishNames = repoDish.GetDishNames();
            dishSelect.ItemsSource = dishNames;
        }

        private void Add_Table_Click(object sender, RoutedEventArgs e)
        {
            Table table = new Table() { TableInfo = TableInfoBox.Text };
            ITableRepository repository = new TableRepository();
            repository.CreateTable(table);
        }

        private void Add_Dish_Click(object sender, RoutedEventArgs e)
        {
            Dish dish = new Dish() { Name = DishNameBox.Text, DishPrice = Convert.ToInt32(DishPriceBox.Text) };
            IDishRepository repository = new DishRepository();
            repository.CreateDish(dish);
        }

        private void Add_Order_Click(object sender, RoutedEventArgs e)
        {
            IDishRepository dishRepo = new DishRepository();
            Order order = new Order() { DishID = Convert.ToInt32(dishRepo.GetDish(dishSelect.Text).DishID), TableID = Convert.ToInt32(tableSelect.Text), TimeStamp = DateTime.Now.ToString("HH:mm:ss") };
            IOrderRepository repository = new OrderRepository();
            repository.CreateOrder(order);
        }
    }
}
