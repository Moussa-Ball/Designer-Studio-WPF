using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Studio.Softer.Workspaces
{
    public class ThreeDimensionalWorkspace : Interoperate.Workspaces.Workspace
    {
        public bool Active {
            get
            {
                return true;
            }
            set
            {
                Active = value;
            }
        }

        public ObservableCollection<MenuItem> GetMainMenuItems()
        {
            return new ObservableCollection<MenuItem>
            {
                new MenuItem { Header = "File" },
                new MenuItem { Header = "Edit" },
                new MenuItem { Header = "Display" },
                new MenuItem { Header = "Tools" },
                new MenuItem { Header = "Window" },
                new MenuItem { Header = "Aide" },
            };
        }
    }
}
