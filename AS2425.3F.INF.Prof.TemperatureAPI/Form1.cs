using System.Text.Json;

// Usefull links
// https://wttr.in/Rimini
// https://wttr.in/Rimini?format=j1
// https://wttr.in/Rimini?format=j1&lang=it
// https://openweathermap.org/api
// https://jsonformatter.org/

namespace AS2425._3F.INF.Prof.TemperatureAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get temperature from https://wttr.in/ public weather API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text.Trim();
            if (string.IsNullOrWhiteSpace(city)) return;

            try
            {
                string url = $"https://wttr.in/{city}?format=j1";

                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    var json = await JsonDocument.ParseAsync(stream);

                    // Display the raw JSON response
                    txtResponse.Text = json.RootElement.ToString();

                    // Parse the JSON to get the weather information
                    var current = json.RootElement
                        .GetProperty("current_condition")[0];

                    string description = current
                        .GetProperty("weatherDesc")[0]
                        .GetProperty("value").GetString() ?? "";

                    string temp = current
                        .GetProperty("temp_C").GetString() ?? "";

                    string emoji = description.Contains("cloud") ? "☁️" :
                        description.Contains("rain") ? "🌧️" :
                        description.Contains("clear") ? "☀️" :
                        description.Contains("snow") ? "❄️" :
                        "🌡️";

                    // show weather information
                    lblTemperatura.Text = $"Weather: {description} {emoji}, Temp: {temp}°C";

                    // show icon
                    string iconUrl = getIconUrlFromDescription(description);
                    picImage.Load(iconUrl);
                }
                else
                {
                    lblTemperatura.Text = "Could not fetch weather.";
                }
            }
            catch (Exception ex)
            {
                txtResponse.Text = "Error: " + ex.Message;
            }
        }

        private string getIconUrlFromDescription(string description)
        {
            description = description.ToLower();
            if (description.Contains("sun") || description.Contains("clear"))
                return "https://openweathermap.org/img/wn/01d.png";
            if (description.Contains("cloud"))
                return "https://openweathermap.org/img/wn/03d.png";
            if (description.Contains("rain"))
                return "https://openweathermap.org/img/wn/09d.png";
            if (description.Contains("snow"))
                return "https://openweathermap.org/img/wn/13d.png";
            if (description.Contains("fog") || description.Contains("mist"))
                return "https://openweathermap.org/img/wn/50d.png";

            return "https://openweathermap.org/img/wn/02d.png"; // default
        }
    }
}
