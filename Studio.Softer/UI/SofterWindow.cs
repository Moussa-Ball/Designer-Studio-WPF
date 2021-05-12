using System.Windows;

namespace Studio.Softer.UI
{
    public class SofterWindow : Windows.UI.MainWindow
    {
        static SofterWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SofterWindow), new FrameworkPropertyMetadata(typeof(SofterWindow)));
        }

        public SofterWindow()
        {
            DataContext = Application.Current.GetService<Services.WorkspaceService>();
        }
    }
}
