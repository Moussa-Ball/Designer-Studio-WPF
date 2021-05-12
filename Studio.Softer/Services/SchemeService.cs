using Studio.Softer.Schemes;
using Studio.Softer.Settings;
using System;

namespace Studio.Softer.Services
{
    public class SchemeService
    {
        /// <summary>
        /// Custom event when the scheme/theme is changed.
        /// </summary>
        public event EventHandler<SchemeManagerEventArgs> SchemeManagerEvent;

        /// <summary>
        /// Instance of <see cref="SchemeSettings"/>.
        /// </summary>
        private SchemeSettings SchemeSettings { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SchemeService()
        {
            SchemeSettings = new SchemeSettings();
        }

        public void ChangeScheme(SchemeEnum scheme)
        {
            SchemeManagerEventArgs args = new SchemeManagerEventArgs();
            args.OldScheme = SchemeManager.GetCurrentScheme();
            args.NewScheme = scheme;

            // Handle event when the scheme is changing.
            OnSchemeChanging(args);

            SchemeManager.ChangeScheme(scheme);
            SchemeSettings.Scheme = scheme;

            // Handle event when the scheme has been change.
            OnSchemeChanged(args);
        }

        /// <summary>
        /// Load schemes configuration.
        /// </summary>
        public void LoadScheme()
        {
            SchemeSettings.LoadSettings();
            SchemeManager.ApplyScheme(SchemeSettings.Scheme);
        }

        /// <summary>
        /// Saves schemes configuration.
        /// </summary>
        public void SaveScheme()
        {
            SchemeSettings.Save();
        }

        protected virtual void OnSchemeChanged(SchemeManagerEventArgs e)
        {
            EventHandler<SchemeManagerEventArgs> handler = SchemeManagerEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        protected virtual void OnSchemeChanging(SchemeManagerEventArgs e)
        {
            EventHandler<SchemeManagerEventArgs> handler = SchemeManagerEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
