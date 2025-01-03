using System;
using System.Text.Json;

namespace JSPManager
{
    public class Config
    {
        public string Token { get; set; } = "insert-your-token";
        public List<AdminConfig> Admins { get; set; }
        public List<GroupConfig> Groups { get; set; }
        

    }
    public class AdminConfig 
    { 
        public int Admin { get; set; }
    }
    public class GroupConfig
    {
        public string GroupNameHuman { get; set; } = "Výbor pro xyz";
        public string GroupName { get; set; } = "group_name";
        public int ChairmenRole { get; set; } = 123456789;
        public int MemberRole { get; set; } = 123456789;
    }
    public class ConfigUtils
    {
        public static async Task CreateConfigAsync()
        {
            try
            {
                Console.WriteLine("Config file not found. Creating one ...");
                var defConf = new Config
                {
                    Groups = new List<GroupConfig>
                    {
                        new GroupConfig
                        {
                            GroupNameHuman="Výbor pro elektrotechniku",
                            GroupName="example_group",
                            ChairmenRole=123456789,
                            MemberRole=123456789,
                        },
                        new GroupConfig
                        {
                            GroupNameHuman="Výbor pro c#",
                            GroupName="example_group2",
                            ChairmenRole=123456789,
                            MemberRole=123456789,
                        }
                    },
                    Admins = new List<AdminConfig>
                    {
                        new AdminConfig
                        {
                            Admin = 123456789
                        },
                        new AdminConfig
                        {
                            Admin = 123456789
                        }
                    }
                };
                var SerializerOptions = new JsonSerializerOptions{ WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                var json = JsonSerializer.Serialize(defConf, SerializerOptions);
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
