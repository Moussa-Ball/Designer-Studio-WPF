using System;
using System.Windows;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Studio.Softer
{
    public static class ResourcesManager
    {
        /// <summary>
        /// Allows to add a resource dictionary for styles.
        /// </summary>
        /// <param name="resourceFilePath">The path of xaml file. Represents the path of resource dictionary file.</param>
        /// <returns></returns>
        public static void AddDictionnaryResource(string resourceFilePath)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri(@"pack://application:,,,/" + Assembly.GetCallingAssembly().GetName().Name +
                ";component" +
                (resourceFilePath[0] == '/' ? resourceFilePath : "/" + resourceFilePath), UriKind.Absolute);
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        public static ImageSource AddImageSource(string resourceFilePath)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(@"pack://application:,,,/" + Assembly.GetCallingAssembly().GetName().Name +
                ";component" +
                (resourceFilePath[0] == '/' ? resourceFilePath : "/" + resourceFilePath), UriKind.Absolute);
            img.EndInit();
            return img;
        }
    }
}
