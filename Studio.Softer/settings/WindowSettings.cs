using System;
using System.Windows;

namespace Studio.Softer.settings
{
    public class WindowSettings : Interoperate.Settings.SettingsBase
    {
        /// <summary>
        /// The width of Main Window.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of Main Window.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The top position of Main Window.
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// The left position of Main Window.
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Window State configuration.
        /// </summary>
        public WindowState WindowState { get; set; }

        /// <summary>
        /// The name of file settings.
        /// </summary>
        public override string Name => "Window";

        /// <summary>
        /// Settings Folder of App.
        /// </summary>
        public override string SettingsFolder => Application.Current.SettingsFolder;

        /// <summary>
        /// Load main window settings.
        /// </summary>
        public override void LoadSettings()
        {
            Top = Read("Top", Top);
            Left = Read("Left", Left);
            Width = Read("Width", Width);
            Height = Read("Height", Height);
            WindowState = (WindowState)Enum.Parse(typeof(WindowState), Read("WindowState", WindowState.ToString()));
        }

        /// <summary>
        /// Write main window settings.
        /// </summary>
        public override void SaveSettings()
        {
            Write("Top", Top);
            Write("Left", Left);
            Write("Width", Width);
            Write("Height", Height);
            Write("WindowState", WindowState);
        }
    }
}
