using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Studio.Softer.UI
{
    public class DockManager
    {
        private int column = 0;
        private Grid MainContainer = null;
        private ContentPresenter DockContainer = null;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public DockManager()
        {
            MainContainer = new Grid();
        }

        /// <summary>
        /// Set the container who host the dock system.
        /// </summary>
        /// <param name="content"></param>
        public void SetContainer(ContentPresenter content)
        {
            DockContainer = content;
            DockContainer.Content = MainContainer;

        }

        /// <summary>
        /// Add a column to position the dock section.
        /// </summary>
        /// <param name="fullwidth"></param>
        /// <returns></returns>
        public ColumnDefinition AddColumn(bool fullwidth = false)
        {
            if (!fullwidth)
                return new ColumnDefinition { Width = new GridLength(400)
                };
            return new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
        }

        /// <summary>
        /// Add a column to split docks side.
        /// </summary>
        /// <returns></returns>
        public ColumnDefinition AddSplitterColumn()
        {
            return new ColumnDefinition { Width = new GridLength(2) };
        }

        /// <summary>
        /// Add a row to position the dock section.
        /// </summary>
        /// <param name="fullheight"></param>
        /// <returns></returns>
        public RowDefinition AddRow(bool fullheight = false)
        {
            if (!fullheight)
                return new RowDefinition { Height = GridLength.Auto };
            return new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
        }

        /// <summary>
        /// Add dock side.
        /// </summary>
        public Grid AddDockSide(DockSide side)
        {
            switch(side)
            {
                case DockSide.Left:
                    MainContainer.ColumnDefinitions.Add(AddColumn());
                    MainContainer.ColumnDefinitions.Add(AddSplitterColumn());
                    break;
                case DockSide.Right:
                    MainContainer.ColumnDefinitions.Add(AddColumn());
                    MainContainer.ColumnDefinitions.Add(AddSplitterColumn());
                    break;
                case DockSide.Middle:
                    MainContainer.ColumnDefinitions.Add(AddColumn(true));
                    break;
            }

            var grid = new Grid { MinWidth = 350, Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#303030") };
            var gridSplitter = new GridSplitter { 
                Width = 2,
                ResizeDirection = GridResizeDirection.Columns,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Right,
                ResizeBehavior = GridResizeBehavior.BasedOnAlignment,
                Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#363636")
            };

            Grid.SetColumn(grid, 0);
            Grid.SetColumn(gridSplitter, 1);

            MainContainer.Children.Add(grid);
            MainContainer.Children.Add(gridSplitter);
            return grid;
        }
    }
}
