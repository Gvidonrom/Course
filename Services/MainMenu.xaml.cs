using System.Windows;

namespace Course.Services
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_ItemInventory_Click(object sender, RoutedEventArgs e)
        {
            ItemInventory itemInventory = new ItemInventory();
            itemInventory.Show();
            Close();
        }
    }
}
