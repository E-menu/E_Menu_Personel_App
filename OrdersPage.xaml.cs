namespace E_Menu_Personel_App
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using E_Menu_Personel_App.Models;
    using System.Collections.Generic;
    using E_Menu_Personel_App.Interfaces;    
    using E_Menu_Personel_App.Repositories;
    using System.Windows;

    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            
            IDishRepository dishRepo = new DishRepository();
            IOrderRepository orderRepo = new OrderRepository();
            int tableCount = 6;
            var orders = orderRepo.GetOrders();
            var dishesInt = orderRepo.GetDishes(1);
            Dish[] dishes1 = new Dish[dishesInt.Length];
            OrderDish[] DO = new OrderDish[dishesInt.Length];
            int foreach_iter = 0;
            IOrderedEnumerable<OrderDish>[] query = new IOrderedEnumerable<OrderDish>[tableCount+1];
            IEnumerable<String> TimeQuery;
            IEnumerable<int> IDQuery;
            double[] TablePrice = new double[tableCount+1];
            for (int table_number = 1; table_number <= tableCount; table_number++)
            {
                dishesInt = orderRepo.GetDishes(table_number);
                dishes1 = new Dish[dishesInt.Length];
                DO = new OrderDish[dishesInt.Length];
                foreach_iter = 0;
                foreach (var x in dishesInt)
                {
                    dishes1[foreach_iter] = dishRepo.GetDish(x);
                    DO[foreach_iter] = new OrderDish
                    {
                        DishPrice = dishes1[foreach_iter].DishPrice,
                        Name = dishes1[foreach_iter].Name
                    };
                    TablePrice[table_number] += dishes1[foreach_iter].DishPrice;
                    foreach_iter++;
                }

                TimeQuery =
                    from o in orders
                    where o.TableID == table_number
                    select o.TimeStamp;

                IDQuery =
                    from o in orders
                    where o.TableID == table_number
                    select o.OrderID;

                foreach_iter = 0;
                foreach (var p in TimeQuery)
                {
                    DO[foreach_iter].TimeStamp = p;
                    foreach_iter++;
                }

                foreach_iter = 0;
                foreach (var p in IDQuery)
                {
                    DO[foreach_iter].OrderID = p;
                    foreach_iter++;
                }

                query[table_number] =
                    DO.Select(n => n)
                    .OrderBy(n => n.TimeStamp)
                    .ThenBy(n => n.Name);
            }

            TablePrice1.Content = TablePrice[1];
            TablePrice2.Content = TablePrice[2];
            TablePrice3.Content = TablePrice[3];
            TablePrice4.Content = TablePrice[4];
            TablePrice5.Content = TablePrice[5];
            TablePrice6.Content = TablePrice[6];
            Stolik1.ItemsSource = query[1];
            Stolik2.ItemsSource = query[2];
            Stolik3.ItemsSource = query[3];
            Stolik4.ItemsSource = query[4];
            Stolik5.ItemsSource = query[5];
            Stolik6.ItemsSource = query[6];



            
        }
        private void Delete_Order1(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik1.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        private void Delete_Order2(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik2.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        private void Delete_Order3(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik3.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        private void Delete_Order4(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik4.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        private void Delete_Order5(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik5.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        private void Delete_Order6(object sender, RoutedEventArgs e)
        {
            var OrderRepo = new OrderRepository();
            OrderDish orderDish = Stolik6.SelectedItem as OrderDish;
            OrderRepo.DeleteOrder(orderDish.OrderID);
            this.NavigationService.Navigate(new OrdersPage());
        }
        public class OrderDish
        {
            public string Name { get; set; }

            public double? DishPrice { set; get; }

            public string TimeStamp { set; get; }

            public int OrderID { get; set; }
        }
    }
}
