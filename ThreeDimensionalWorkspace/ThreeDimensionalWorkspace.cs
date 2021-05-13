using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Studio.Softer.Workspaces
{
    public class ThreeDimensionalWorkspace : Interoperate.Workspaces.Workspace
    {
        /// <summary>
        /// Defines if the workspace is active or not.
        /// </summary>
        public bool Active
        {
            get
            {
                return true;
            }
            set
            {
                Active = value;
            }
        }

        /// <summary>
        /// Allowzs to get the all the main menu items.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Represents the icon of this workspace
        /// </summary>
        public override ImageSource WorkspaceIcon()
        {
            return ResourcesManager.AddImageSource("resources/color-cirlce.png");
        }
    }
}
