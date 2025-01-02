using System;
using System.Text.Json;

namespace JSPManager
{
    public class Config
    {
        public string Token { get; set; } = "insert-your-token";

    }
    public class ConfigUtils
    {
        public static async Task CreateConfigAsync()
        {
            try
            {
                Console.WriteLine("Config file not found. Creating one ...");
                var defConf = new Config();
                var json = JsonSerializer.Serialize(defConf);
                await File.WriteAllTextAsync("config.json", json);
                Console.WriteLine("Configuration file created" + json);
            }
            catch (Exception e) {
                Console.WriteLine("An error has occoured while trying to create configuration file " + e.Message);
            }
        }
        public static async Task<Config> ParseConfigAsync()
        {
            try
            {
                string _config = await File.ReadAllTextAsync("config.json");
                var config = JsonSerializer.Deserialize<Config>(_config);
                Logging.LogInfo("Config successfully parsed");
                return config;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occoured while trying to parse configuration file " + e.Message);
                return null;
            }
        }
    }
}
