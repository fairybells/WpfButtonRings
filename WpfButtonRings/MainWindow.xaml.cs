using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Fields & Properties

        /// <summary>
        /// The data context.
        /// </summary>
        private readonly DemoDataContext _dataContext;

        #endregion

        #region Methods

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // Initialize data context.
            _dataContext = new DemoDataContext();

            // Parse XAML.
            InitializeComponent();

            // Assign data context.
            DataContext = _dataContext;
        }
        #endregion

        #region Event handlers

        #region OnAddButtonCommandExecuted
        /// <summary>
        /// Called when the add button command is executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void OnAddButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if ((e.OriginalSource as Button)?.Content is Path buttonContentPath)
            {
                // Ask the data context, whether this content is currently enabled.
                if (_dataContext.IsArrowEnabled)
                {
                    // Add new button ring item.
                    _dataContext.AddRingItem(buttonContentPath);
                }
            }
            else
            {
                // Extract content.
                string content =
                    (e.OriginalSource as Button)?.Content as string;
                // Ask the data context, whether this content is currently enabled (this will also ensure, content is currently not null).
                if (_dataContext.IsLetterEnabled(content))
                {
                    // Add new button ring item.
                    _dataContext.AddRingItem(content);
                }
            }
        } 
        #endregion

        #region OnAddButtonCommandCanExecute
        /// <summary>
        /// Called when to check, whether the add button command can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void OnAddButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((e.OriginalSource as Button)?.Content is Path)
            {
                e.CanExecute = _dataContext.IsArrowEnabled;
            }
            else
            {
                // Extract content.
                string content =
                    (e.OriginalSource as Button)?.Content as string;
                // Ask the data context, whether this content is currently enabled.
                e.CanExecute =
                    _dataContext.IsLetterEnabled(content);
            }
        }
        #endregion

        #region OnRemoveButtonCommandExecuted
        /// <summary>
        /// Called when the remove button command is executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void OnRemoveButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Make sure there are at least two items left.
            if (_dataContext.ButtonRingItems.Count < 3)
            {
                // Abort.
                return;
            }

            // Make sure the source is a button ring item.
            if (e.OriginalSource is ButtonRingItem item)
            {
                if (item.Content is Path)
                {
                    // Check again, whether the content is currently enabled.
                    if (_dataContext.IsArrowEnabled)
                    {
                        _dataContext.RemoveRingItem(item);
                    }
                }
                else
                {
                    // Check again, whether the content is currently enabled.
                    if (_dataContext.IsLetterEnabled(item.Content as string))
                    {
                        _dataContext.RemoveRingItem(item);
                    }
                }
            }
        } 
        #endregion

        #region OnRemoveButtonCommandCanExecute
        /// <summary>
        /// Called when to check, whether the remove button command can be executed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void OnRemoveButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check whether there are more than two items left.
            if (_dataContext.ButtonRingItems.Count < 3)
            {
                e.CanExecute = false;
            }
            else
            {
                if ((e.OriginalSource as ButtonRingItem)?.Content is Path)
                {
                    e.CanExecute = _dataContext.IsArrowEnabled;
                }
                else
                {
                    // Extract content.
                    string content =
                        (e.OriginalSource as ButtonRingItem)?.Content as string;
                    // Ask the data context, whether this content is currently enabled.
                    e.CanExecute =
                        _dataContext.IsLetterEnabled(content);
                }
            }
        } 
        #endregion

        #endregion

        #endregion
    }
}
