using System;
using System.Text.Json;
using Discord;
using Discord.WebSocket;

namespace JSPManager {
    public class Program
    {
        private static DiscordSocketClient _client;
        public static async Task Main()
        {

            Logging.LogInfo("JSP Manager version 0.1 starting ...");

            if (!File.Exists("config.json"))
            {
                ConfigUtils.CreateConfig();
                return;
            }
            string _config = await File.ReadAllTextAsync("config.json");
            var config = JsonSerializer.Deserialize<Config>(_config);
            Logging.LogInfo("Config successfully parsed");

            _client = new DiscordSocketClient();
            _client.Log += Logging.Log;
            await _client.LoginAsync(TokenType.Bot, config.token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    }
}