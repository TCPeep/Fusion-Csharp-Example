using Fusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FusionAPI_WPF_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static FusionApp App = new FusionApp("YOURFUSIONAPPID"); // Your application ID needs to go here you can read our docs if you cant find it https://docs.fusionapi.dev/

        public Login()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginResponse = await App.Login(tbUsername.Text, tbPassword.Password, "", false, false);
            if (loginResponse.Error == false)
            {
                new MainWindow().Show();
                Hide();
                MessageBox.Show(loginResponse.Message, "FusionAPI.dev", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(loginResponse.Message, "FusionAPI.dev", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            new Register().Show();
            Hide();
        }
    }
}
