using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Studio.Softer.Windows.UI
{
    [TemplatePart(Name = PART_WindowButtonCommands, Type = typeof(ContentPresenter))]
    public class MainWindow : Window
    {
        private const string PART_WindowButtonCommands = "PART_WindowButtonCommands";

        public static readonly DependencyProperty WindowButtonCommandsProperty = DependencyProperty.Register(nameof(WindowButtonCommands), typeof(WindowButtonCommands), typeof(MainWindow), new PropertyMetadata(null, UpdateLogicalChilds));

        /// <summary>
        /// Gets/sets the window button commands that hosts the min/max/close commands.
        /// </summary>
        public WindowButtonCommands WindowButtonCommands
        {
            get { return (WindowButtonCommands)GetValue(WindowButtonCommandsProperty); }
            set { SetValue(WindowButtonCommandsProperty, value); }
        }

        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }

        public MainWindow()
        {
            DataContextChanged += MainWindow_DataContextChanged;
        }

        private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // MahApps add these controls to the window with AddLogicalChild method.
            // This has the side effect that the DataContext doesn't update, so do this now here.
            if (WindowButtonCommands != null) WindowButtonCommands.DataContext = DataContext;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (WindowButtonCommands == null) {
                WindowButtonCommands = new WindowButtonCommands();
            }
        }

        private static void UpdateLogicalChilds(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var window = dependencyObject as MainWindow;
            if (window == null)
            {
                return;
            }

            var oldChild = e.OldValue as FrameworkElement;
            if (oldChild != null)
            {
                window.RemoveLogicalChild(oldChild);
            }

            var newChild = e.NewValue as FrameworkElement;
            if (newChild != null)
            {
                window.AddLogicalChild(newChild);
                // Yes, that's crazy. But we must do this to enable all possible scenarios for setting DataContext
                // in a Window. Without set the DataContext at this point it can happen that e.g. a Flyout
                // doesn't get the same DataContext.
                // So now we can type
                //
                // this.InitializeComponent();
                // this.DataContext = new MainViewModel();
                //
                // or
                //
                // this.DataContext = new MainViewModel();
                // this.InitializeComponent();
                //
                newChild.DataContext = window.DataContext;
            }
        }

        /// <inheritdoc />
        protected override IEnumerator LogicalChildren
        {
            get
            {
                // cheat, make a list with all logical content and return the enumerator
                ArrayList children = new ArrayList();
                if (this.WindowButtonCommands != null)
                {
                    children.Add(this.WindowButtonCommands);
                }
                return children.GetEnumerator();
            }
        }
    }
}
