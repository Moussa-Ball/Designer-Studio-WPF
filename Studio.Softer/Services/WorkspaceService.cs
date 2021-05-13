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
        /// Contains a list of workspace who will be use in an application.
        /// </summary>
        public WorkspaceContainer workspaceContainer { get; private set; }
        public WorkspaceContainer WorkspaceContainer { 
            get 
            { 
                return workspaceContainer; 
            } 
            private set 
            {
                workspaceContainer = value;
                OnPropertyChanged("WorkspaceContainer");
            } 
        }

        #endregion

        /// <summary>
        /// Initialize a new list of container.
        /// </summary>
        public WorkspaceService()
        {
            WorkspaceContainer = new WorkspaceContainer();
        }

        /// <summary>
        /// Allows to get the active workspace.
        /// </summary>
        private void GetActiveWorkspace()
        {
            foreach (var workspace in WorkspaceContainer)
            {
                if((bool)workspace.GetType().GetProperty("Active").GetValue(workspace, null))
                {
                    MenuItems = (ObservableCollection<MenuItem>)workspace.GetType().GetMethod("GetMainMenuItems").Invoke(workspace, null);
                }
            }
        }

        /// <summary>
        /// Load All workspaces.
        /// </summary>
        public void StartupAllWorkspaces()
        {
            GetActiveWorkspace();
        }

        /// <summary>
        /// Save All workspaces.
        /// </summary>
        public void SavesAllWorkspacesStates() {}
    }
}
