
using System.Windows.Input;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// 
    /// </summary>
    public static class DemoCommands
    {
        #region Fields & Properties

        /// <summary>
        /// The add button command.
        /// </summary>
        public static readonly RoutedUICommand AddButtonCommand =
            new RoutedUICommand("Add Button", nameof(AddButtonCommand), typeof(DemoCommands));

        /// <summary>
        /// The remove button command.
        /// </summary>
        public static readonly RoutedUICommand RemoveButtonCommand =
            new RoutedUICommand("Remove Button", nameof(RemoveButtonCommand), typeof(DemoCommands));

        #endregion

        #region Methods

        #endregion
    }
}
