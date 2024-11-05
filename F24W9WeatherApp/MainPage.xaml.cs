namespace F24W9WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherBtnClicked(object sender, EventArgs e)
        {
            var loc = await Geolocation.Default.GetLocationAsync();
            var lat = loc.Latitude;
            var lon = loc.Longitude;

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=adee4d9d26685357054efd2f06359807";

            var myWeather = await WeatherProxy.GetWeatherAsync(url);

            CityLbl.Text = myWeather.name;
            TemperatureLbl.Text = myWeather.main.temp.ToString();
            ConditionsLbl.Text = myWeather.weather[0].description;
        }
    }

}
