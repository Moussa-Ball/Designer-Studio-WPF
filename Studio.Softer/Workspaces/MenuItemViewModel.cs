using System.Diagnostics;
using Studio.Softer.Windows;
using System.Collections.Generic;

namespace Studio.Softer.Workspaces
{
    public interface IMenuItemViewModel {}

    [DebuggerDisplay("---")]
    public class SeparatorViewModel : IMenuItemViewModel {}

    [DebuggerDisplay("{Header}, Children={Children.Count}")]
    public class MenuItemViewModel : NotifyPropertyChanged, IMenuItemViewModel
    {
        public MenuItemViewModel()
        {
            Children = new List<IMenuItemViewModel>();
            Children.Add(new MenuItemViewModel("File"));
        }

        public MenuItemViewModel(string header)
        {
            Header = header;
            Children = new List<IMenuItemViewModel>();
        }

        public string Header { get; private set; }
        public IList<IMenuItemViewModel> Children { get; private set; }
    }
}
