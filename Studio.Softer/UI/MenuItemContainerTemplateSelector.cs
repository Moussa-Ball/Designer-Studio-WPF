using System.Windows;
using System.Windows.Controls;
using Studio.Softer.Interoperate;

namespace Studio.Softer.UI
{
    public class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
    {
        public MenuItemContainerTemplateSelector()
        {
            Logger.Info("MenuItemContainerTemplateSelector: Constructor Called !");
        }

        public override DataTemplate SelectTemplate(object item, ItemsControl parentItemsControl)
        {
            Logger.Info("MenuItemContainerTemplateSelector: Template Selector Called !");
            var key = new DataTemplateKey(item.GetType());
            return (DataTemplate)parentItemsControl.FindResource(key);
        }
    }
}
