using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusMediaInterviewTask.Utility
{
    public class ConfigProperties
    {
        public static string CalculateBillApi { get; } = ConfigManager.GetConfiguration("CalculateBillApi");
    }
}
