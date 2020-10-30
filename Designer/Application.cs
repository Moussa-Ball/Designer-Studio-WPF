using System;
using Studio.Softer;
using System.Reflection;
using System.Windows.Media;

namespace Designer
{
    /// <summary>
    /// Main class of this application (Coder Studio).
    /// </summary>
    public class Application : Studio.Softer.Application
    {
        /// <summary>
        /// Main method called by the application.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main()
        {
            new Application().RunApplicationAsSingleInstance();
        }

        /// <summary>
        /// The full name of this application.
        /// </summary>
        public override string FullName => "Designer Studio";

        /// <summary>
        /// The short name of this application.
        /// </summary>
        public override string ShortName => "Designer";

        /// <summary>
        /// The Guid of this application.
        /// </summary>
        /// <returns></returns>
        public override string Guid => "{92D9B836-E220-4D3A-AD61-C5EF12798D7F}";

        /// <summary>
        /// The version of this application.
        /// NB: Contains the major, minor, build & revision number.
        /// </summary>
        public override string Version => Assembly.GetEntryAssembly().GetName().Version.ToString();

        /// <summary>
        /// Get the current app domain.
        /// </summary>
        public static new Application Current => (Application)System.Windows.Application.Current;

        /// <summary>
        /// The Major version of this application.
        /// </summary>
        public override string MajorVersion => Assembly.GetEntryAssembly().GetName().Version.Major.ToString();

        /// <summary>
        /// The Minor version of this application.
        /// </summary>
        public override string MinorVersion => Assembly.GetEntryAssembly().GetName().Version.Minor.ToString();

        /// <summary>
        /// The Build number of this application.
        /// </summary>
        public override string Build => Assembly.GetEntryAssembly().GetName().Version.Build.ToString();

        /// <summary>
        /// The revision number of this application.
        /// </summary>
        public override string Revision => Assembly.GetEntryAssembly().GetName().Version.Revision.ToString();

        /// <summary>
        /// The major revision number of this application.
        /// </summary>
        public override string MajorRevision => Assembly.GetEntryAssembly().GetName().Version.MajorRevision.ToString();

        /// <summary>
        /// The minor revision number of this application.
        /// </summary>
        public override string MinorRevision => Assembly.GetEntryAssembly().GetName().Version.MinorRevision.ToString();

        /// <summary>
        /// Contains the log file path.
        /// </summary>
        public override string logFilePath => GetOrCreateFilePath(Environment.SpecialFolder.ApplicationData, FullName, "logging.log");

        /// <summary>
        /// Represents the main icon of an application.
        /// </summary>
        public override ImageSource Icon => ResourcesManager.AddImageSource("Icons/designer.png");
    }
}
