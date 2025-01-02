using System;
using System.Text.Json;

namespace JSPManager
{
    public class Config
    {
        public string token { get; set; } = "insert-your-token";
    }
    public class ConfigUtils
    {
        public static async Task CreateConfig()
        {
            try
            {
                Console.WriteLine("Config file not found. Creating one ...");
                var DefConf = new Config();
                var json = JsonSerializer.Serialize(DefConf);
                await File.WriteAllTextAsync("config.json", json);
                Console.WriteLine("Configuration file created" + json);
            }
            catch (Exception e) {
                Console.Write("An error has occoured while trying to create configuration file" + e.Message);
            }
        }
    }
}
