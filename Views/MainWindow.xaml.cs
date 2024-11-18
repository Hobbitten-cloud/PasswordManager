using PasswordManager.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            // Databinds the information from backend code to the design area
            DataContext = mainViewModel;

            // NOTE - Has to be false and later enabled once all required fields *
            BT_SavePassword.IsEnabled = true;
        }

        private void BT_NewPassword_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.AddDefaultManager();
            LB_Manager.ScrollIntoView(mainViewModel.SelectedManager);
        }

        private void BT_DeletePassword_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this manager?",
                "Delete manager",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                mainViewModel.DeleteSelectedManager();
                LB_Manager.ScrollIntoView(mainViewModel.SelectedManager);
            }
        }

        private void BT_SavePassword_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?",
                "Save file",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                mainViewModel.SaveAllManagers();
            }
        }
    }
}