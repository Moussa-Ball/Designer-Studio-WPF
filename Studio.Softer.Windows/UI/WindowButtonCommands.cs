using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Studio.Softer.Windows.UI
{
    [TemplatePart(Name = "PART_Min", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Max", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Close", Type = typeof(Button))]
    public class WindowButtonCommands : Button
    {
        public event ClosingWindowEventHandler ClosingWindow;
        public delegate void ClosingWindowEventHandler(object sender, ClosingWindowEventHandlerArgs args);

        /// <summary>
        /// Identifies the <see cref="Minimize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimizeProperty
            = DependencyProperty.Register(nameof(Minimize),
                                          typeof(string),
                                          typeof(WindowButtonCommands),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the minimize button tooltip.
        /// </summary>
        public string Minimize
        {
            get => (string)GetValue(MinimizeProperty);
            set => SetValue(MinimizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Maximize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximizeProperty
            = DependencyProperty.Register(nameof(Maximize),
                                          typeof(string),
                                          typeof(WindowButtonCommands),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the maximize button tooltip.
        /// </summary>
        public string Maximize
        {
            get => (string)GetValue(MaximizeProperty);
            set => SetValue(MaximizeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Close"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseProperty
            = DependencyProperty.Register(nameof(Close),
                                          typeof(string),
                                          typeof(WindowButtonCommands),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the close button tooltip.
        /// </summary>
        public string Close
        {
            get => (string)GetValue(CloseProperty);
            set => SetValue(CloseProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Restore"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RestoreProperty
            = DependencyProperty.Register(nameof(Restore),
                                          typeof(string),
                                          typeof(WindowButtonCommands),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the restore button tooltip.
        /// </summary>
        public string Restore
        {
            get => (string)GetValue(RestoreProperty);
            set => SetValue(RestoreProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ParentWindow"/> dependency property.
        /// </summary>
        internal static readonly DependencyPropertyKey ParentWindowPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ParentWindow),
                                                typeof(Window),
                                                typeof(WindowButtonCommands),
                                                new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="ParentWindow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ParentWindowProperty = ParentWindowPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the window.
        /// </summary>
        public Window ParentWindow
        {
            get => (Window)GetValue(ParentWindowProperty);
            protected set => SetValue(ParentWindowPropertyKey, value);
        }

        static WindowButtonCommands() 
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowButtonCommands), new FrameworkPropertyMetadata(typeof(WindowButtonCommands)));
        }

        public WindowButtonCommands()
        {
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, MinimizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, MaximizeWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, RestoreWindow));
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, CloseWindow));

            // Add Tooltip for buttons commands and get the main window from helper function.
            Dispatcher.BeginInvoke((Action)(() => {
                if (null == ParentWindow)
                {
                    var window = this.TryFindParent<Window>();
                    SetValue(ParentWindowPropertyKey, window);
                }

                if (string.IsNullOrWhiteSpace(Minimize))
                {
                    SetCurrentValue(MinimizeProperty, GetCaption(900));
                }

                if (string.IsNullOrWhiteSpace(Maximize))
                {
                    SetCurrentValue(MaximizeProperty, GetCaption(901));
                }

                if (string.IsNullOrWhiteSpace(Close))
                {
                    SetCurrentValue(CloseProperty, GetCaption(905));
                }

                if (string.IsNullOrWhiteSpace(Restore))
                {
                    SetCurrentValue(RestoreProperty, GetCaption(903));
                }
            }), DispatcherPriority.Loaded);
        }

        private void MinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                SystemCommands.MinimizeWindow(ParentWindow);
            }
        }

        private void MaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                SystemCommands.MaximizeWindow(ParentWindow);
            }
        }

        private void RestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                SystemCommands.RestoreWindow(ParentWindow);
            }
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                var args = new ClosingWindowEventHandlerArgs();
                ClosingWindow?.Invoke(this, args);

                if (args.Cancelled)
                {
                    return;
                }

                SystemCommands.CloseWindow(ParentWindow);
            }
        }

#pragma warning disable 618
        private string GetCaption(int id)
        {
            if (user32 == null)
            {
                user32 = UnsafeNativeMethods.LoadLibrary(Environment.SystemDirectory + "\\User32.dll");
            }

            var sb = new StringBuilder(256);
            UnsafeNativeMethods.LoadString(user32, (uint)id, sb, sb.Capacity);
            return sb.ToString().Replace("&", "");
        }

        private SafeLibraryHandle user32;
#pragma warning restore 618
    }
}
