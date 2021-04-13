using Studio.Softer.UI;
using Studio.Softer.Settings;

namespace Studio.Softer.Services
{
    public class WindowService
    {
        /// <summary>
        /// Get Main Window.
        /// </summary>
        public SofterWindow MainWindow { get; private set; }

        /// <summary>
        /// Get Window Configuration.
        /// </summary>
        public WindowSettings Settings { get; private set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public WindowService()
        {
            Settings = new WindowSettings();
        }

        /// <summary>
        /// Create an instance of main window.
        /// </summary>
        public void CreateInstance()
        {
            MainWindow = new SofterWindow
            {
                Icon = Application.Current.Icon, // The main icon of application.
                Title = Application.Current.FullName, // The application name
            };
            LoadWindowSettings();
            MainWindow.Closing += SaveWindowSettings;
        }

        /// <summary>
        /// Show the main window.
        /// </summary>
        public void Show()
        {
            Application.Current.MainWindow = MainWindow;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Load Main Window Settings.
        /// </summary>
        private void LoadWindowSettings()
        {
            Settings.LoadSettings();
            MainWindow.Width = Settings.Width;
            MainWindow.Height = Settings.Height;
            MainWindow.WindowState = Settings.WindowState;
            MainWindow.Top = (Settings.Top > 0) ? Settings.Top : 100;
            MainWindow.Left = (Settings.Left > 0) ? Settings.Top : 100;
        }

        /// <summary>
        /// Saves all window settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveWindowSettings(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                Settings.Top = MainWindow.RestoreBounds.Top;
                Settings.Left = MainWindow.RestoreBounds.Left;
                Settings.Width = MainWindow.RestoreBounds.Width;
                Settings.Height = MainWindow.RestoreBounds.Height;
            } else
            {
                Settings.Top = MainWindow.Top;
                Settings.Left = MainWindow.Left;
                Settings.Width = MainWindow.Width;
                Settings.Height = MainWindow.Height;
            }
            Settings.WindowState = MainWindow.WindowState;
            Settings.Save();
        }
    }
}
