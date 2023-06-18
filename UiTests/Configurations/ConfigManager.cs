using Microsoft.Extensions.Configuration;

namespace UiTests.Configurations
{
	public static class ConfigManager
    {
        private static readonly IConfigurationRoot ConfigurationRoot = SetupConfiguration();

        public static string GetSectionValue(string key) => ConfigurationRoot.GetSection(key).Value;

        public static T BindConfiguration<T>() where T : IConfiguration
        {
            var config = Activator.CreateInstance<T>();
            ConfigurationRoot.GetSection(config.JsonSectionName).Bind(config);
            return config;
        }

        public static IConfigurationRoot SetupConfiguration()
        {
            var environmentConfig = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}