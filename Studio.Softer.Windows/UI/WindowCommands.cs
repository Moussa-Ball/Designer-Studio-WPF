using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Controls;

namespace Studio.Softer.Windows.UI
{
    public class WindowCommands : Border
    {
        static WindowCommands()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowCommands), new FrameworkPropertyMetadata(typeof(WindowCommands)));
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            var window = this.TryFindParent<Window>();

            if (e.ClickCount == 2) 
            {
                window.WindowState = (window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            }
            else 
            {
                // Move the window from window titlre bar on click.
                Point point = Mouse.GetPosition(this);
                Point wpfPoint = PointToScreen(point);
                int x = Convert.ToInt16(wpfPoint.X);
                int y = Convert.ToInt16(wpfPoint.Y);
                IntPtr windowHandle = new WindowInteropHelper(window).Handle;
                NativeMethods.SendMessage(windowHandle, WM.NCLBUTTONDOWN, (IntPtr)HT.CAPTION, new IntPtr(x | (y << 16)));
            }
        }

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);
            var window = this.TryFindParent<Window>();
            SystemCommands.ShowSystemMenu(window, e);
        }
    }
}
