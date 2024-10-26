using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArgusMediaInterviewTask.Utility
{
    public class ConfigManager
    {
        private static IConfiguration Conf { get; set; }
        public ConfigManager()
        {
            Conf = new ConfigurationBuilder()
                .AddJsonFile("Config.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public string GetConfiguration(string key)
        {
            return Conf.GetValue<string>(key);
        }

        public static string GetCurrentlyExecutingDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
        }

    }
}
