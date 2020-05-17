using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// A single button of the <see cref="ButtonRing"/>.
    /// </summary>
    public class ButtonRingItem : ContentControl
    {
        #region Fields & Properties

        /// <summary>
        /// The command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ButtonRingItem));

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion

        #region Methods

        #endregion
    }
}
