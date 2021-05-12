using System.Windows.Controls;
using Studio.Softer.Workspaces;
using System.Collections.ObjectModel;

namespace Studio.Softer.Services
{
    public class WorkspaceService : Windows.NotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Contains the list of menu items for the applications.
        /// </summary>
        private ObservableCollection<MenuItem> menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            private set
            {
                menuItems = value;
                OnPropertyChanged("MenuItems");
            }
        }

        /// <summary>
        /// Contains a list of container who will be use in an application.
        /// </summary>
        public WorkspaceContainer WorkspaceContainer { get; private set; }

        #endregion

        /// <summary>
        /// Initialize a new list of container.
        /// </summary>
        public WorkspaceService()
        {
            WorkspaceContainer = new WorkspaceContainer();
        }

        /// <summary>
        /// Load All workspaces.
        /// </summary>
        public void StartupAllWorkspaces()
        {
            foreach (var workspace in WorkspaceContainer)
            {
                MenuItems = (ObservableCollection<MenuItem>)workspace.GetType().GetMethod("GetMainMenuItems").Invoke(workspace, null);
            }
        }

        /// <summary>
        /// Save All workspaces.
        /// </summary>
        public void SavesAllWorkspacesStates() {}
    }
}
