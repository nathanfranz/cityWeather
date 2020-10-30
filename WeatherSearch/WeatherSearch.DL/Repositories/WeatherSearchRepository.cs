using RestSharp;
using WeatherSearch.Models;

namespace WeatherSearch.DL.Repositories
{
    public static class WeatherSearchRepository
    {
        // Initialize rest client
        private const string BaseAddress = "https://api.openweathermap.org/data/2.5";
        private static IRestClient _weatherClient = new RestClient(BaseAddress);
        
        // API Key 
        private const string ApiKey = "00f529dd202ee16b980ec0ead48f78d5";
        private const string ApiKeyQuery = "&appid=" + ApiKey;
        
        // Routes
        private const string WeatherRoute = "/weather";

        public static WeatherData GetWeatherDataFromCity(string city)
        {
            var uri = WeatherRoute + "?q=" + city + ApiKeyQuery;
            var userRequest = new RestRequest(uri, Method.GET);

            var response =  _weatherClient.Execute<WeatherData>(userRequest);
            return response.Data;
        }
    }
}