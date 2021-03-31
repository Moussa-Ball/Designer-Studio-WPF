namespace Studio.Softer.Services
{
    public class WindowService
    {
        public void CreateInstance() => Application.Current.MainWindow = new UI.SofterWindow
        {
            Width = 1280, // Default width of main window.
            Height = 768, // Default height of main window.
            Icon = Application.Current.Icon, // The main icon of application.
            Title = Application.Current.FullName // The application name
        };

        public void Run()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
