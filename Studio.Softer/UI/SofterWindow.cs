using System.Windows;

namespace Studio.Softer.UI
{
    internal class SofterWindow : Windows.UI.MainWindow
    {
        static SofterWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SofterWindow), new FrameworkPropertyMetadata(typeof(SofterWindow)));
        }
    }
}
