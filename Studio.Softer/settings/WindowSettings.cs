using System.ComponentModel;

namespace Studio.Softer.settings
{
    public class WindowSettings
    {
        [DefaultValue(1280)]
        public double Width { get; set; }

        [DefaultValue(768)]
        public double Height { get; set; }
    }
}
