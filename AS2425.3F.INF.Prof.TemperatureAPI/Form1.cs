using System.Text.Json;

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

                    // show weather information
                    lblTemperatura.Text = $"Weather: {description}, Temp: {temp}°C";
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
    }
}
