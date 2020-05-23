using System;
using System.Configuration;

namespace RealEstateManagementCLI.Configuration
{
    public static class AppConfiguration
    {
        public static string ReadFilePath()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var result = appSettings["filePath"];

            if (result.Equals(""))
            {
                throw new FilePathNotSpecifiedException();
            }

            return result;
        }

        public static void SpecifyPath(string filePath)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["filePath"].Value = filePath;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}