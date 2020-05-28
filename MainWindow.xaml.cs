namespace E_Menu_Personel_App
{
    using System;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class MainWindow : Window
    {       
        DebugOutput outputter;
        public MainWindow()
        {
            InitializeComponent();
            
            //---------Debug----------
            outputter = new DebugOutput(DebugBox);
            Console.SetOut(outputter);
            Console.WriteLine("Started");
            //-----------------------------------            
        }
        
        //popup new window to add order
        private void Click_Add(object sender, RoutedEventArgs e)
        {

            var AddWindow = new AddWindow();
            AddWindow.Show();
        }     

        //popup new window to ask user about Exit
        private void Button3_Click(object sender, RoutedEventArgs e)
        {                        
            var ExitWindow = new AskForExit();
            ExitWindow.ShowDialog();
        }

        //create new instance of timer and tick every 100ms
        private void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);            
            dt.Tick += timer_tick;
            dt.Start();
        }

        //passing time to the label
        public void timer_tick(object sender, EventArgs e)
        {
            Timer.Content = DateTime.Now.ToLongTimeString();            
        }

        //loading new frame with orders
        private void Order_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(10);
            dt.Tick += refresh;
            dt.Start();            
            Orders.Content = new OrdersPage();
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            Orders.Content = new OrdersPage();
        }
        public void refresh(object sender, EventArgs e)
        {
            Orders.Content = new OrdersPage();
        }
        public void Connect_Server(object sender, RoutedEventArgs e)
        {
            
            new Thread(() =>
            {
                Connection CNT = new Connection();
                Thread.CurrentThread.IsBackground = true;
                CNT.Connect("127.0.0.1", "\u0022PCAPPK");
            }).Start();
        }
    }    
}
