using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Interop;

namespace Studio.Softer.Windows.UI
{
    public class WindowTitleBar : Border
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this);
            var wih = new WindowInteropHelper(window);
            IntPtr hwnd = wih.Handle;
            var wpfPoint = window.PointToScreen(Mouse.GetPosition(window));
            var x = (int)wpfPoint.X;
            var y = (int)wpfPoint.Y;
            NativeMethods.SendMessage(hwnd, WM.NCLBUTTONDOWN, (IntPtr)HT.CAPTION, new IntPtr(x | (y << 16)));

            if (e.ClickCount == 2)
            {
                window.WindowState = (window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            }

            base.OnMouseLeftButtonDown(e);
        }
    }
}
