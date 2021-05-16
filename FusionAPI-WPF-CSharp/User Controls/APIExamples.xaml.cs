using Fusion;
using Newtonsoft.Json;
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

namespace FusionAPI_WPF_CSharp.User_Controls
{
    /// <summary>
    /// Interaction logic for APIExamples.xaml
    /// </summary>
    public partial class APIExamples : UserControl
    {
        public APIExamples()
        {
            InitializeComponent();
        }

        private async void btnTrack_Click(object sender, RoutedEventArgs e)
        {
            var apiResponse = await FusionApp.ExecuteAPI("1528750760833494526", tbIP.Text);
            if (apiResponse.Error == false)
            {
                MessageBox.Show($"{apiResponse.Message}{Environment.NewLine}{Environment.NewLine}Raw Response{Environment.NewLine}{apiResponse.Response}");

                FreeGEO geoResults = JsonConvert.DeserializeObject<FreeGEO>(apiResponse.Response);

                lblCity.Content = geoResults.city;
                lblCountryCode.Content = geoResults.country_code;
                lblCountryName.Content = geoResults.country_name;
                lblLatLon.Content = $"{geoResults.latitude} / {geoResults.longitude}";
                lblRegionName.Content = geoResults.region_name;
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
            }
        }

        public class FreeGEO
        {
            public string ip { get; set; }
            public string country_code { get; set; }
            public string country_name { get; set; }
            public string region_code { get; set; }
            public string region_name { get; set; }
            public string city { get; set; }
            public string zip_code { get; set; }
            public string time_zone { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public int metro_code { get; set; }
        }
    }
}
