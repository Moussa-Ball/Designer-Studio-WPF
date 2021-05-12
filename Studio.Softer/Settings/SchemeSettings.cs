using System;

namespace Studio.Softer.Settings
{
    public class SchemeSettings : Interoperate.Settings.SettingsBase
    {
        /// <summary>
        /// The name of file settings.
        /// </summary>
        public override string Name => "Schemes";

        /// <summary>
        /// Settings Folder of App.
        /// </summary>
        public override string SettingsFolder => Application.Current.SettingsFolder;

        /// <summary>
        /// Get The Scheme.
        /// </summary>
        public Schemes.SchemeEnum Scheme { get; set; }

        public override void LoadSettings()
        {
            Scheme = (Schemes.SchemeEnum)Enum.Parse(typeof(Schemes.SchemeEnum), Read("Scheme", Scheme.ToString()));
        }

        public override void SaveSettings()
        {
            Write("Scheme", Scheme);
        }
    }
}
