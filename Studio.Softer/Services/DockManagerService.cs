using Studio.Softer.UI;
using System.Windows.Controls;
using System.Activities.Presentation;

namespace Studio.Softer.Services
{
    public class DockManagerService : Windows.NotifyPropertyChanged
    {
        #region Properties

        private ContentPresenter dockManagerContainer;
        public ContentPresenter DockManagerContainer
        {
            get
            {
                return dockManagerContainer;
            }
            set
            {
                dockManagerContainer = value;
                OnPropertyChanged(nameof(DockManagerContainer));
            }
        }

        private ServiceManager serviceManager;
        public ServiceManager ServiceManager
        {
            get
            {
                return serviceManager;
            }
            set
            {
                serviceManager = value;
                OnPropertyChanged(nameof(ServiceManager));
            }
        }

        #endregion


        public DockManagerService(ServiceManager services)
        {
            ServiceManager = services;
        }


        public void GetDockContainerElement(ContentPresenter content)
        {
            DockManagerContainer = content;
            DockManager dockManager = new DockManager();
            dockManager.SetContainer(DockManagerContainer);
            dockManager.AddDockSide(DockSide.Left);
            dockManager.AddDockSide(DockSide.Left);
        }
    }
}
