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
using System.Windows.Shapes;

namespace FusionAPI_WPF_CSharp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerResponse = await Login.App.Register(tbUsername.Text, tbPassword.Password, tbToken.Password);
            if (registerResponse.Error == false)
            {
                new Login().Show();
                Hide();
                MessageBox.Show(registerResponse.Message, "FusionAPI.dev", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(registerResponse.Message, "FusionAPI.dev", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
