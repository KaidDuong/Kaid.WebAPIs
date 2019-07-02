

using System.Configuration;

namespace Kaid.WebAPI.Common
{
    public  class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
