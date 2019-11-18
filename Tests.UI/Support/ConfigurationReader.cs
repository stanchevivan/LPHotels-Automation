
using System;
using System.IO;
using System.Json;

namespace Tests.UI.Support
{
    public static class ConfigurationReader
    {
        private static readonly JsonValue configuration;
        private static string environment;

        static ConfigurationReader()
        {
            string result = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Support/Environments.json"));
            configuration = JsonValue.Parse(result);
        }

        public static void Initialize(string env)
        {
            environment = env;

        }

        public static string URL => configuration[environment]["URL"];
        public static string URL_Salesforce => configuration[environment]["URL_SF"];
        public static string User => configuration[environment]["User"];
        public static string Password => configuration[environment]["Password"];
    }
}