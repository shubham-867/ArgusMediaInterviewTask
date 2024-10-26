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

        /// <summary>
        /// get the key value based on key name
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfiguration(string key)
        {
            return Conf.GetValue<string>(key);
        }
        
    }
}
