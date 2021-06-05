using System.Windows.Controls;
using System.Activities.Presentation;
using Studio.Softer.Windows.UI.MDI;

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

        private DocumentManagerSelector documentManagerSelector;
        public DocumentManagerSelector DocumentManagerSelector
        {
            get
            {
                return documentManagerSelector;
            }
            set
            {
                documentManagerSelector = value;
                OnPropertyChanged(nameof(DocumentManagerSelector));
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
            DockManagerContainer.Content = DocumentManagerSelector = new DocumentManagerSelector();
        }
    }
}
