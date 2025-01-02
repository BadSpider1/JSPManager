using System;
using Discord;

namespace JSPManager {
    public class Logging
    {
        public static Task Log(LogMessage msg)
        {
            Console.WriteLine("[Discord.NET] - " + msg.ToString());
            return Task.CompletedTask;
        }
        public static Task LogInfo(string msg)
        {
            Console.WriteLine("[INFO] - " + DateTime.Now.ToString("HH:mm:ss ") + msg);
            return Task.CompletedTask;
        }
    }

}