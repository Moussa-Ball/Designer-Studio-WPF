using System;
using System.Windows;
using System.Threading;
using System.Windows.Media;
using System.ComponentModel;
using Studio.Softer.Services;
using Studio.Softer.settings;
using System.Windows.Threading;
using Studio.Softer.Interoperate;
using Studio.Softer.Interoperate.Services;
using Studio.Softer.Interoperate.Settings;

namespace Studio.Softer
{
    public abstract class Application : Interoperate.Application
    {
        UI.SplashScreen m_splash;

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
        /// Default constructor of this class.
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
                // Show the splashscreen
                m_splash = new UI.SplashScreen();
                m_splash.Show();
                Run(m_splash);
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
            Logger.Info("Starting Application");
            ResourcesManager.AddDictionnaryResource("Schemes/DarkScheme.xaml");
            ResourcesManager.AddDictionnaryResource("Styles/CoreStyle.xaml");
            base.OnStartup(e);
        }

        /// <summary>
        /// Allows to register any services used for an application.
        /// </summary>
        /// <param name="services"></param>
        protected override void RegisterServices(ServiceManager services)
        {
            base.RegisterServices(services);
            services.Publish(new WindowService());
        }

        /// <summary>
        /// It is called after all the services have been registered.
        /// </summary>
        /// <param name="services"></param>
        protected override void OnServicesRegistered(ServiceManager services)
        {
            base.OnServicesRegistered(services);
            // Creates a new instance of main window and shows it.
            GetService<WindowService>().CreateInstance();
            GetService<WindowService>().Show();
            
            // Async thread for UI to c
            Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (Action)(() => {
                m_splash.Close();
            }));
        }
    }
}
