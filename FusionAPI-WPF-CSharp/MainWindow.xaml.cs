using FusionAPI_WPF_CSharp.User_Controls;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tabDisplay.Children.Add(new Information());
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            tabDisplay.Children.Clear();
            tabDisplay.Children.Add(new Information());
        }

        private void btnAPIs_Click(object sender, RoutedEventArgs e)
        {
            tabDisplay.Children.Clear();
            tabDisplay.Children.Add(new APIExamples());
        }

        private void btnBonus_Click(object sender, RoutedEventArgs e)
        {
            tabDisplay.Children.Clear();
            tabDisplay.Children.Add(new Bonus());
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
