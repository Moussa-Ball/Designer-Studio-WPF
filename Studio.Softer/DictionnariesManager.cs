using System;
using System.Reflection;
using System.Windows;

namespace Studio.Softer
{
    internal static class DictionnariesManager
    {
        /// <summary>
        /// Allows to add a resource dictionary for styles.
        /// </summary>
        /// <param name="resourceFilePath">The path of xaml file. Represents the path of resource dictionary file.</param>
        /// <returns></returns>
        public static void AddResource(string resourceFilePath)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri(@"pack://application:,,,/" + Assembly.GetCallingAssembly().GetName().Name + 
                ";component" +
                (resourceFilePath[0] == '/' ? resourceFilePath : "/" + resourceFilePath), UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}
