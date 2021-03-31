using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Studio.Softer.Windows.UI.Controls
{
    [TemplatePart(Name = "PART_ItemsHolder", Type = typeof(Panel))]
    public class SofterControl : Selector
    {
        private Panel _itemsHolder;

        // Using a DependencyProperty as the backing store for TabTearTriggerDistance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabPersistBehaviorProperty =
            DependencyProperty.Register("SofterPersistBehavior", typeof(SofterPersistBehavior), typeof(SofterControl),
                new PropertyMetadata(SofterPersistBehavior.None, OnTabPersistBehaviorPropertyChanged));

        private static void OnTabPersistBehaviorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SofterControl softerControl = (SofterControl)d;
            if (((SofterPersistBehavior)e.NewValue) == SofterPersistBehavior.None)
            {
                softerControl._itemsHolder.Children.Clear();
            }
            else
            {
                softerControl.SetSelectedContent(false);
            }
        }

        /// <summary>
        /// Controls the persist behavior of tabs. All = all tabs live in memory, None = no tabs live in memory, Timed= tabs gets cleared from memory after a period of being unselected.
        /// </summary>
        public SofterPersistBehavior TabPersistBehavior
        {
            get => (SofterPersistBehavior)GetValue(TabPersistBehaviorProperty);
            set => SetValue(TabPersistBehaviorProperty, value);
        }

        static SofterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SofterControl), new FrameworkPropertyMetadata(typeof(SofterControl)));

        }

        /// <summary>
        /// Set <see cref="_itemsHolder"/> template child.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _itemsHolder = GetTemplateChild("PART_ItemsHolder") as Panel;
            SetSelectedContent(false);
        }

        /// <summary>
        /// Allows to set selected content.
        /// </summary>
        /// <param name="removeContent">If the content can be removed or not.</param>
        protected void SetSelectedContent(bool removeContent)
        {

        }
    }
}
