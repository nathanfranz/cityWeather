using System;

namespace WeatherSearch.Models
{
    public class WeatherData
    {
        public Main main { get; set; }
        
        public Wind wind { get; set; } 
    }

    public class Main
    {
        public string temp { get; set; }
        
        public string humidity { get; set; }
    }
    
    public class Wind
    {
        public string speed { get; set; }
        
        public string deg { get; set; }
    }
}