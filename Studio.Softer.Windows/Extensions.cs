using System.Windows;

namespace Studio.Softer.Windows
{
    public static class Extensions
    {
        public static Rect GetAbsolutePlacement(this FrameworkElement element, bool relativeToScreen = false)
        {
            var absolutePos = element.PointToScreen(new Point(0, 0));
            if (relativeToScreen)
            {
                return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
            }
            var posMW = Application.Current.MainWindow.PointToScreen(new Point(0, 0));
            absolutePos = new Point(absolutePos.X - posMW.X, absolutePos.Y - posMW.Y);
            return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
        }
    }
}
