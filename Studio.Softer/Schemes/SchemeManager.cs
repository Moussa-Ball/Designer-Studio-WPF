using System;
using System.Windows;
using System.Reflection;

namespace Studio.Softer.Schemes
{
    /// <summary>
    /// A class that allows for the detection and alteration of a theme.
    /// </summary>
    public static class SchemeManager
    {
        private static ResourceDictionary _resourceDictionary = null;

        public static SchemeEnum OldScheme { get; private set; }
        public static SchemeEnum NewScheme { get; private set; }

        /// <summary>
        /// Get the current Scheme.
        /// </summary>
        /// <returns></returns>
        public static SchemeEnum GetCurrentScheme()
        {
            return OldScheme;
        }

        /// <summary>
        /// Get a valid Scheme path existing in the Schemes Directory.
        /// </summary>
        /// <param name="scheme"></param>
        /// <returns></returns>
        private static string GetValidScheme(SchemeEnum scheme)
        {
            string resourceFilePath = string.Empty;
            switch (scheme)
            {
                case SchemeEnum.DARK:
                    resourceFilePath = "Schemes/DarkScheme.xaml";
                    OldScheme = SchemeEnum.DARK;
                    break;
                case SchemeEnum.LIGHT:
                    resourceFilePath = "Schemes/LightScheme.xaml";
                    OldScheme = SchemeEnum.LIGHT;
                    break;
            }

            if (string.IsNullOrEmpty(resourceFilePath))
                throw new ArgumentNullException("The scheme you are looking for was not found!");

            return resourceFilePath;
        }

        /// <summary>
        /// Apply a scheme/theme for the application.
        /// Generally called when the application starts.
        /// </summary>
        /// <param name="scheme"></param>
        public static void ApplyScheme(SchemeEnum scheme)
        {
            string resourceFilePath = GetValidScheme(scheme);
            _resourceDictionary = new ResourceDictionary();
            _resourceDictionary.Source = new Uri(@"pack://application:,,,/" + Assembly.GetCallingAssembly().GetName().Name +
                ";component" +
                (resourceFilePath[0] == '/' ? resourceFilePath : "/" + resourceFilePath), UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
        }

        /// <summary>
        /// Replace the current scheme/theme with another scheme/theme.
        /// </summary>
        /// <param name="scheme"></param>
        public static void ChangeScheme(SchemeEnum scheme)
        {
            /*
             * Check if the new scheme is not the old scheme.
             * If yes, we throw an SchemeException. 
             */
            if (OldScheme == scheme)
                throw new SchemeException("The current scheme is the same as the one you want to change.");

            // Get the valid scheme.
            NewScheme = scheme;
            string resourceFilePath = GetValidScheme(scheme);            

            // Apply the new scheme.
            _resourceDictionary.Source = new Uri(@"pack://application:,,,/" + Assembly.GetCallingAssembly().GetName().Name +
                ";component" +
                (resourceFilePath[0] == '/' ? resourceFilePath : "/" + resourceFilePath), UriKind.Absolute);
            var schemeResourceIndex = Application.Current.Resources.MergedDictionaries.IndexOf(_resourceDictionary);
            Application.Current.Resources.MergedDictionaries[schemeResourceIndex] = _resourceDictionary;
        }
    }
}
