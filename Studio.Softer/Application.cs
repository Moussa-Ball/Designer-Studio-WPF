using System.Windows;
using System.Threading;
using System.Windows.Media;
using Studio.Softer.Interoperate;

namespace Studio.Softer
{
    public abstract class Application : Interoperate.Application
    {
        /// <summary>
        /// Mutex instance used to manage the single instance.
        /// </summary>
        private Mutex m_mutex;

        /// <summary>
        /// Represents the main icon of an application.
        /// </summary>
        public abstract ImageSource Icon { get; }

        /// <summary>
        /// Get the current app domain.
        /// </summary>
        public static new Application Current => (Application)System.Windows.Application.Current;

        /// <summary>
        /// Defualt constructor of this class.
        /// </summary>
        public Application()
        {
            Logger.Open(FullName, logFilePath);
        }

        /// <summary>
        /// Runs the application in a single instance, otherwise it stops.
        /// </summary>
        protected void RunApplicationAsSingleInstance()
        {
            m_mutex = new Mutex(true, $"{Current.Guid}-{Current.Version}", out bool newInstance);

            if (newInstance)
            {
                m_mutex.ReleaseMutex();
                MainWindow = new UI.SofterWindow
                {
                    Icon = Icon,
                    Width = 1280,
                    Height = 768,
                    Title = FullName
                };
                MainWindow.Show();
                Run(MainWindow);
            }
            else
            {
                Logger.Warning($"{FullName} is already running. Shutting down.");
                Shutdown();
            }
        }

        /// <summary>
        /// Is called when the application starts.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            ResourcesManager.AddDictionnaryResource("Schemes/DarkScheme.xaml");
            ResourcesManager.AddDictionnaryResource("Styles/CoreStyle.xaml");
            base.OnStartup(e);
        }
    }
}
