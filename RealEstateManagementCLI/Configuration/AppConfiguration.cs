using System;
using System.Configuration;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Configuration
{
    /// <summary>
    /// This class handles interactions with the app.config.
    /// </summary>
    public static class AppConfiguration
    {
        /// <summary>
        /// Reads the path of the XML file.
        /// </summary>
        /// <returns>The path of the XML file.</returns>
        /// <exception cref="FilePathNotSpecifiedException">Throws if path is not specified.</exception>
        public static string ReadFilePath()
        {
            var result = ReadValue("filePath");

            if (result.Equals(""))
            {
                throw new FilePathNotSpecifiedException();
            }

            return result;
        }

        /// <summary>
        /// Specifies the path of the XML file.
        /// </summary>
        /// <param name="filePath">The path of the XML file.</param>
        public static void SpecifyPath(string filePath)
        {
            if (filePath != null)
            {
                SetValue("filePath", filePath);
            }
            else
            {
                throw new FilePathNotNullException();
            }
        }

        /// <summary>
        /// Reads the <see cref="SerializationType"/> of the application.
        /// </summary>
        /// <returns>The <see cref="SerializationType"/> that is configured in the app.config.</returns>
        /// <exception cref="FilePathNotSpecifiedException"></exception>
        public static SerializationType ReadSerializationType()
        {
            var result = ReadValue("serializationType");

            if (result.Equals(""))
            {
                // TODO: Create new Exception.
                throw new FilePathNotSpecifiedException();
            }

            return Enum.Parse<SerializationType>(result);
        }

        /// <summary>
        /// Specifies the <see cref="SerializationType"/> in the app.config.
        /// </summary>
        /// <param name="serializationType"></param>
        public static void SpecifySerializationType(SerializationType serializationType)
        {
            // TODO: Add exception.
            SetValue("serializationType", serializationType.ToString());
        }

        /// <summary>
        /// A method to set existing values in the app.config file.
        /// </summary>
        /// <param name="key">The key of the value that should be changed.</param>
        /// <param name="value">The value that is applied to the key.</param>
        private static void SetValue(string key, string value)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Returns a value from the app.config file.
        /// </summary>
        /// <param name="key">The key of the value that should be returned.</param>
        /// <returns>A value from the app.config file.</returns>
        private static string ReadValue(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var result = appSettings[key];

            return result;
        }
    }
}