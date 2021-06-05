using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Studio.Softer.Windows.UI.MDI
{
    /// <summary>
    /// ALLOWS TO HANDLE DOCK SYSTEM.
    /// </summary>
    [TemplatePart(Name = PART_ItemsHolder, Type = typeof(Panel))]
    public class DocumentManagerSelector : Selector
    {
        #region Private Members

        /// <summary>
        /// the name of Main Dock Container.
        /// </summary>
        private const string PART_ItemsHolder = "PART_ItemsHolder";

        private Panel _itemsHolder = null;

        #endregion

        static DocumentManagerSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentManagerSelector), 
                new FrameworkPropertyMetadata(typeof(DocumentManagerSelector)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _itemsHolder = GetTemplateChild("PART_ItemsHolder") as Panel;
        }
    }
}
