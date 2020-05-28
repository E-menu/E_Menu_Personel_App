
namespace E_Menu_Personel_App
{
    using System;    
    using System.Text;
    using System.Threading;
    using System.Net.Sockets;
    using E_Menu_Personel_App.Interfaces;
    using E_Menu_Personel_App.Repositories;
    using E_Menu_Personel_App.Models;

    public class Connection
    {
        public void Add_To_Datebase(string data)
        {
            IDishRepository repoDish = new DishRepository();
            IOrderRepository repository = new OrderRepository();
            Order order;
            Dish dish;
            int tableID = Int32.Parse(char.ToString(data[0]));
            data = data.Remove(0, 2);
            Console.WriteLine(data);
            Console.WriteLine(tableID);
            string[] Dish_Price = data.Split(";");
            foreach (var x in Dish_Price)
            {
                order = new Order();
                dish = new Dish();
                Console.WriteLine(x);
                string[] element = x.Split(",");
                dish.Name = element[0];
                dish.DishPrice = Convert.ToInt32(element[1]);
                var ID = repoDish.CheckDish(dish);
                if (ID == 0)
                {
                    order.DishID = repoDish.CreateDish(dish);
                }
                else order.DishID = ID;

                order.TableID = tableID;
                order.TimeStamp = DateTime.Now.ToString("HH:mm:ss");
                repository.CreateOrder(order);
            }
        }
        public void Connect(String server, String message)
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();
                Byte[] data = new Byte[256];
                data = Encoding.ASCII.GetBytes(message);
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Thread.Sleep(200);
                Byte[] tmp1 = new Byte[2];
                stream.Read(tmp1, 0, 2);
                string resp = Encoding.ASCII.GetString(tmp1, 0, 2);
                if (resp == "OK")
                {
                    Console.WriteLine("Connected");
                }
                else
                {
                    Console.WriteLine("Error in connection");
                }
                stream.FlushAsync(); 
                while (true)
                {                   
                    stream = client.GetStream();
                    data = new Byte[256];
                    String response = String.Empty;
                    // Read the Tcp Server Response Bytes.
                    Byte[] length = new Byte[1];
                    while (!stream.DataAvailable) ;
                    stream.Read(length, 0, 1); //check length of response in bytes
                    if (length[0] != 0) //0 bit is ping byte
                    {
                        int bytes_count = stream.Read(data, 0, length[0]);
                        response = Encoding.ASCII.GetString(data, 0, bytes_count);
                        Console.WriteLine("Received: {0}", response);
                        Add_To_Datebase(response);
                    }
                    stream.FlushAsync();
                    Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            Console.Read();
        }
    }
}
