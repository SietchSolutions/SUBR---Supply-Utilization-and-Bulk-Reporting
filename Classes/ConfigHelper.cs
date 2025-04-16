using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SUBR___Supply_Utilization_and_Bulk_Reporting

{
    public static class ConfigHelper
    {
        private static readonly string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logConfig.json");
        private static JObject config;

        static ConfigHelper()
        {
            try
            {
                if (!File.Exists(configPath))
                    throw new FileNotFoundException("logConfig.json not found!");

                var jsonText = File.ReadAllText(configPath);
                config = JObject.Parse(jsonText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error loading config: " + ex.Message);
                config = new JObject(); // fallback
            }
        }
        public static string GetMaterialCsvPath()
        {
            return config["materialCsvPath"]?.ToString() ?? "";
        }
        public static string GetEDMCLogPath()
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logConfig.json");
                if (!File.Exists(configPath))
                    return ""; // Or default

                var json = JObject.Parse(File.ReadAllText(configPath));
                return json["edmcLogPath"]?.ToString() ?? "";
            }
            catch
            {
                return "";
            }
        }

        public static string GetLogFilePath()
        {
            return config["logFileDirectory"]?.ToString() ?? string.Empty;
        }

        public static string GetInaraApiKey()
        {
            return config["inaraApiKey"]?.ToString() ?? string.Empty;
        }

        // Add this if you plan to use more values later
        public static string GetValue(string key)
        {
            return config[key]?.ToString() ?? string.Empty;
        }
    }
}
