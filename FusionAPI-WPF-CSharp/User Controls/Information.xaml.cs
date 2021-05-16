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
using Fusion;

namespace FusionAPI_WPF_CSharp.User_Controls
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : UserControl
    {
        public Information()
        {
            InitializeComponent();

            lblUsername.Content = User.Username;
            lblExpiry.Content = User.Expiry;
            lblUserID.Content = User.UserId;
            lblLevel.Content = Convert.ToString(User.Level);
            lblIP.Content = "****************";
            lblhwid.Content = User.HardwareId;
            lblUserCount.Content = Fusion.App.UserCount;
            lblApis.Content = Fusion.App.ApiCount;
            lblActiveApis.Content = Fusion.App.ActiveApis;
            lblAppName.Content = Fusion.App.AppName;
            lblAppDesc.Content = Fusion.App.AppDescription;
        }

        private async void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await FusionApp.RefreshApp();

            lblUserCount.Content = Fusion.App.UserCount;
            lblApis.Content = Fusion.App.ApiCount;
            lblActiveApis.Content = Fusion.App.ActiveApis;
            lblAppName.Content = Fusion.App.AppName;
            lblAppDesc.Content = Fusion.App.AppDescription;
        }

        private void cbShowIP_Click(object sender, RoutedEventArgs e)
        {
            if (cbShowIP.IsChecked == true)
                lblIP.Content = User.Ip;
            else
                lblIP.Content = "****************";
        }
    }
}
