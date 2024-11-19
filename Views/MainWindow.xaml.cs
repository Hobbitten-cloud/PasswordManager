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

            // NOTE - All fields has to be disabled for input before the button "Change" Has been clicked on the list id
            TB_Name.IsEnabled = false;
            TB_Username.IsEnabled = false;
            TB_Password.IsEnabled = false;
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
                TB_Name.IsEnabled = false;
                TB_Username.IsEnabled = false;
                TB_Password.IsEnabled = false;
            }
        }

        private void ButtonCopy_Name_Click(object sender, RoutedEventArgs e)
        {
            if (mainViewModel.SelectedManager != null && mainViewModel.SelectedManager.Name != null)
            {
                Clipboard.SetText(mainViewModel.SelectedManager.Name);
                ButtonCopy_Name.Opacity = 50;
            }
        }

        private void ButtonCopy_Username_Click(object sender, RoutedEventArgs e)
        {
            if (mainViewModel.SelectedManager != null && mainViewModel.SelectedManager.Username != null)
            {
                Clipboard.SetText(mainViewModel.SelectedManager.Username);
                ButtonCopy_Username.Opacity = 50;
            }
        }

        private void ButtonCopy_Password_Click(object sender, RoutedEventArgs e)
        {
            if (mainViewModel.SelectedManager != null && mainViewModel.SelectedManager.Password != null)
            {
                Clipboard.SetText(mainViewModel.SelectedManager.Password);
                ButtonCopy_Password.Background = new SolidColorBrush(Colors.Blue);
            }
        }

        private void BT_makeChange_Click(object sender, RoutedEventArgs e)
        {
            TB_Name.IsEnabled = true;
            TB_Username.IsEnabled = true;
            TB_Password.IsEnabled = true;
        }
    }
}