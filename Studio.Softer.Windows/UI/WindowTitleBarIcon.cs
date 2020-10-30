using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Studio.Softer.Windows.UI
{
    public class WindowTitleBarIcon : Image
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this);
            SystemCommands.ShowSystemMenuPhysicalCoordinates(window,
                new Point(window.GetAbsolutePlacement(true).X, 37 + window.GetAbsolutePlacement(true).Y));

            if (e.ClickCount == 2) {
                return;
            }

            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this);
            SystemCommands.ShowSystemMenu(window, e);
            base.OnMouseRightButtonUp(e);
        }
    }
}
