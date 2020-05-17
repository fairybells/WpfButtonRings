using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// 
    /// </summary>
    public class DemoDataContext : INotifyPropertyChanged
    {
        #region Fields & Properties

        #region ControlSize

        /// <summary>
        /// Backing field for <see cref="ControlSize"/>.
        /// </summary>
        private double _controlSize = 200.0;

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        public double ControlSize
        {
            get => _controlSize;
            set => SetProperty(ref _controlSize, value);
        }

        #endregion

        #region RingDistance

        /// <summary>
        /// Backing field for <see cref="RingDistance"/>.
        /// </summary>
        private double _ringDistance = 3.0;

        /// <summary>
        /// Gets or sets the ring distance.
        /// </summary>
        /// <value>
        /// The ring distance.
        /// </value>
        public double RingDistance
        {
            get => _ringDistance;
            set => SetProperty(ref _ringDistance, value);
        }

        #endregion

        #region RingWidth

        /// <summary>
        /// Backing field for <see cref="RingWidth"/>.
        /// </summary>
        private double _ringWidth = 20.0;

        /// <summary>
        /// Gets or sets the width of the ring.
        /// </summary>
        /// <value>
        /// The width of the ring.
        /// </value>
        public double RingWidth
        {
            get => _ringWidth;
            set => SetProperty(ref _ringWidth, value);
        }

        #endregion

        #region RingRotation

        /// <summary>
        /// Backing field for <see cref="RingRotation"/>.
        /// </summary>
        private double _ringRotation;

        /// <summary>
        /// Gets or sets the ring rotation.
        /// </summary>
        /// <value>
        /// The ring rotation.
        /// </value>
        public double RingRotation
        {
            get => _ringRotation;
            set => SetProperty(ref _ringRotation, value);
        }

        #endregion

        #region ButtonDistance

        /// <summary>
        /// Backing field for <see cref="ButtonDistance"/>.
        /// </summary>
        private double _buttonDistance = 20.0;

        /// <summary>
        /// Gets or sets the button distance.
        /// </summary>
        /// <value>
        /// The button distance.
        /// </value>
        public double ButtonDistance
        {
            get => _buttonDistance;
            set => SetProperty(ref _buttonDistance, value);
        }

        #endregion

        #region ButtonDistanceMode

        /// <summary>
        /// Backing field for <see cref="ButtonDistanceMode"/>.
        /// </summary>
        private ButtonRing.DistanceMode _buttonDistanceMode = ButtonRing.DistanceMode.TotalDistance;

        /// <summary>
        /// Gets the button distance mode.
        /// </summary>
        /// <value>
        /// The button distance mode.
        /// </value>
        public ButtonRing.DistanceMode ButtonDistanceMode
        {
            get => _buttonDistanceMode;
            private set => SetProperty(ref _buttonDistanceMode, value);
        }

        #endregion

        #region IsTotalButtonDistance

        /// <summary>
        /// Backing field for <see cref="IsTotalButtonDistance"/>.
        /// </summary>
        private bool _isTotalButtonDistance = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is total button distance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is total button distance; otherwise, <c>false</c>.
        /// </value>
        public bool IsTotalButtonDistance
        {
            get => _isTotalButtonDistance;
            set
            {
                SetProperty(ref _isTotalButtonDistance, value);
                ButtonDistanceMode =
                    value
                        ? ButtonRing.DistanceMode.TotalDistance
                        : ButtonRing.DistanceMode.IndividualDistance;
            }
        }

        #endregion

        #region RotateContents

        /// <summary>
        /// Backing field for <see cref="RotateContents"/>.
        /// </summary>
        private bool _rotateContents;

        /// <summary>
        /// Gets or sets a value indicating whether button ring contents should be rotated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if button ring contents should be rotated; otherwise, <c>false</c>.
        /// </value>
        public bool RotateContents
        {
            get => _rotateContents;
            set => SetProperty(ref _rotateContents, value);
        }

        #endregion

        #region ButtonRingItems

        /// <summary>
        /// Backing field for <see cref="ButtonRingItems"/>.
        /// </summary>
        private List<ButtonRingItem> _buttonRingItems;

        /// <summary>
        /// Gets or sets the button ring items.
        /// </summary>
        /// <value>
        /// The button ring items.
        /// </value>
        public List<ButtonRingItem> ButtonRingItems
        {
            get => _buttonRingItems;
            set => SetProperty(ref _buttonRingItems, value);
        }

        #endregion

        #region IsAEnabled

        /// <summary>
        /// Backing field for <see cref="IsAEnabled"/>.
        /// </summary>
        private bool _isAEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is a enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsAEnabled
        {
            get => _isAEnabled;
            set => SetProperty(ref _isAEnabled, value);
        }

        #endregion

        #region IsBEnabled

        /// <summary>
        /// Backing field for <see cref="IsBEnabled"/>.
        /// </summary>
        private bool _isBEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is b enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is b enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsBEnabled
        {
            get => _isBEnabled;
            set => SetProperty(ref _isBEnabled, value);
        }

        #endregion

        #region IsCEnabled

        /// <summary>
        /// Backing field for <see cref="IsCEnabled"/>.
        /// </summary>
        private bool _isCEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is c enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is c enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCEnabled
        {
            get => _isCEnabled;
            set => SetProperty(ref _isCEnabled, value);
        }

        #endregion

        #region IsDEnabled

        /// <summary>
        /// Backing field for <see cref="IsDEnabled"/>.
        /// </summary>
        private bool _isDEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is d enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is d enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDEnabled
        {
            get => _isDEnabled;
            set => SetProperty(ref _isDEnabled, value);
        }

        #endregion

        #region IsEEnabled

        /// <summary>
        /// Backing field for <see cref="IsEEnabled"/>.
        /// </summary>
        private bool _isEEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is e enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is e enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEEnabled
        {
            get => _isEEnabled;
            set => SetProperty(ref _isEEnabled, value);
        }

        #endregion

        #region IsFEnabled

        /// <summary>
        /// Backing field for <see cref="IsFEnabled"/>.
        /// </summary>
        private bool _isFEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is f enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is f enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFEnabled
        {
            get => _isFEnabled;
            set => SetProperty(ref _isFEnabled, value);
        }

        #endregion

        #region IsArrowEnabled

        /// <summary>
        /// Backing field for <see cref="IsArrowEnabled"/>.
        /// </summary>
        private bool _isArrowEnabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is arrow enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is arrow enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsArrowEnabled
        {
            get => _isArrowEnabled;
            set => SetProperty(ref _isArrowEnabled, value);
        }

        #endregion

        #region IsBorderVisible

        /// <summary>
        /// Backing field for <see cref="IsBorderVisible"/>.
        /// </summary>
        private bool _isBorderVisible = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is border visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is border visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsBorderVisible
        {
            get => _isBorderVisible;
            set
            {
                SetProperty(ref _isBorderVisible, value);
                BorderBrush =
                    value
                        ? Brushes.Black
                        : Brushes.Transparent;
            }
        }

        #endregion

        #region BorderBrush

        /// <summary>
        /// Backing field for <see cref="BorderBrush"/>.
        /// </summary>
        private Brush _borderBrush = Brushes.Black;

        /// <summary>
        /// Gets or sets the border brush.
        /// </summary>
        /// <value>
        /// The border brush.
        /// </value>
        public Brush BorderBrush
        {
            get => _borderBrush;
            private set => SetProperty(ref _borderBrush, value);
        }

        #endregion

        #endregion

        #region Events & Delegates

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion

        #region Methods

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoDataContext"/> class.
        /// </summary>
        public DemoDataContext()
        {
            _buttonRingItems = new List<ButtonRingItem>
            {
                CreateRingItem("A"),
                CreateRingItem("B"),
                CreateRingItem("C"),
            };
        }
        #endregion

        #region Public methods

        #region AddRingItem (string)
        /// <summary>
        /// Adds the ring item.
        /// </summary>
        /// <param name="content">The content.</param>
        public void AddRingItem(string content)
        {
            ModifyButtonRingItems(items => items.Add(CreateRingItem(content)));
        }
        #endregion

        #region AddRingItem (Path)
        /// <summary>
        /// Adds the ring item.
        /// </summary>
        /// <param name="content">The content.</param>
        public void AddRingItem(Path content)
        {
            ModifyButtonRingItems(items => items.Add(CreateRingItem(CopyPath(content))));
        }
        #endregion

        #region RemoveRingItem
        /// <summary>
        /// Removes the ring item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void RemoveRingItem(ButtonRingItem item)
        {
            ModifyButtonRingItems(items => items.Remove(item));
        }
        #endregion

        #region IsLetterEnabled
        /// <summary>
        /// Determines whether [is letter enabled] [the specified letter].
        /// </summary>
        /// <param name="letter">The letter.</param>
        /// <returns>
        ///   <c>true</c> if [is letter enabled] [the specified letter]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsLetterEnabled(string letter)
        {
            if (string.IsNullOrWhiteSpace(letter))
            {
                return false;
            }

            switch (letter.ToUpper())
            {
                case "A": return IsAEnabled;
                case "B": return IsBEnabled;
                case "C": return IsCEnabled;
                case "D": return IsDEnabled;
                case "E": return IsEEnabled;
                case "F": return IsFEnabled;
                default: return false;
            }
        } 
        #endregion

        #endregion

        #region Event handlers

        #region OnPropertyChanged
        /// <summary>
        /// Called when a property value changes.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #endregion

        #region Utility methods

        #region SetProperty
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="backingField">The backing field.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        private void SetProperty<TProperty>(ref TProperty backingField, TProperty value, [CallerMemberName] string propertyName = null)
        {
            // Set new value.
            backingField = value;
            // Notify listeners.
            OnPropertyChanged(propertyName);
        }
        #endregion

        #region CreateRingItem
        /// <summary>
        /// Creates the ring item.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        private ButtonRingItem CreateRingItem(object content)
        {
            ButtonRingItem result =
                new ButtonRingItem
                {
                    Content = content,
                    ToolTip = (content is string) ? content : "Arrow",
                    Command = DemoCommands.RemoveButtonCommand,
                };

            return result;
        }
        #endregion

        #region ModifyButtonRingItems
        /// <summary>
        /// Modifies the button ring items.
        /// </summary>
        /// <param name="itemsModification">The items modification.</param>
        /// <remarks>
        /// I could not find a way to get the rotation and size of a button ring item, that gets updated when
        /// items are added to an ItemsSource. So as a workaround, the ItemsSource has to be set to <c>null</c>
        /// and re-set to its actual value again, when adding or removing buttons, to trigger a complete
        /// re-rendering of all button ring items.
        /// </remarks>
        private void ModifyButtonRingItems(Action<List<ButtonRingItem>> itemsModification)
        {
            // Get button ring items.
            List<ButtonRingItem> items = ButtonRingItems;
            // Set to null.
            ButtonRingItems = null;
            // Apply modification.
            itemsModification(items);
            // Re-set again.
            ButtonRingItems = items;
        }
        #endregion

        #region CopyPath
        /// <summary>
        /// Copies the path.
        /// </summary>
        /// <param name="originalPath">The original path.</param>
        /// <returns></returns>
        private Path CopyPath(Path originalPath)
        {
            Path result =
                new Path
                {
                    Data = originalPath.Data,
                };
            Binding binding =
                new Binding("Foreground")
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Button), 1),
                };
            BindingOperations.SetBinding(result, Shape.FillProperty, binding);

            return result;
        } 
        #endregion

        #endregion

        #endregion
    }
}
