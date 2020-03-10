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

namespace WeatherAPI
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string CoCity = "Zlin";
        private string url = $"http://api.openweathermap.org/data/2.5/weather?q={CoCity}&appid=41a61665eb46babbfdb06c73a74b7ee8";

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async Task Load_Click()
        {
            var weatherInfo = await Processor.Load<WeatherWeatherModel>(url);
            var weatherRoot = await Processor.Load<WeatherModel>(url);


            weather.Text = $"Weather: {Math.Round(weatherInfo.Main.Temp - 273.15, 2)} °C";
            weatherFeels.Text = $"Feels like: {Math.Round(weatherInfo.Main.Feels_like - 273.15, 2)} °C";
            weatherMax.Text = $"Max temperature: {Math.Round(weatherInfo.Main.Temp_max - 273.15, 2)} °C";
            weatherMin.Text = $"Min temperature: {Math.Round(weatherInfo.Main.Temp_min - 273.15, 2)} °C";

            city.Text = $"{weatherRoot.Name}";

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Load_Click();
        }
    }
}
