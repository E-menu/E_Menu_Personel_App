namespace E_Menu_Personel_App
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for AskForExit.xaml
    /// </summary>
    public partial class AskForExit : Window
    {
        public AskForExit()
        {
            InitializeComponent();
        }

        //Event handler when user click EXIT, exiting app
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();            
        }
        //Event handler when user click CANCEL, closing popup window
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
