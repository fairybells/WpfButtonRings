using System;
using System.Windows;
using System.Windows.Controls;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// A ring of buttons.
    /// </summary>
    /// <remarks>
    /// This <see cref="ButtonRing"/> is intended to hold multiple buttons; it will not work, if its Items collection or ItemsSource contain zero or only a single item.
    /// Also, if there are exactly two items in its Items collection or ItemsSource, it will do strange thins if the distance between both buttons is set to zero.
    /// </remarks>
    public class ButtonRing : ItemsControl
    {
        #region Constants

        // Note: Some of these initial values are needed to specify default values in case they are not specified 
        //       explicitly when using this control, others are needed to ensure dependent properties have the correct
        //       value with respect to the properties they depend on, since coercing values only happens, when a
        //       dependency property changes, not when it is initialized.

        /// <summary>
        /// The initial control size.
        /// </summary>
        private const double InitialControlSize = 200.0;

        /// <summary>
        /// The initial ring distance.
        /// </summary>
        private const double InitialRingDistance = 3.0;

        /// <summary>
        /// The initial ring width.
        /// </summary>
        private const double InitialRingWidth = 20.0;

        /// <summary>
        /// The initial ring rotation.
        /// </summary>
        private const double InitialRingRotation = 0.0;

        /// <summary>
        /// The initial button distance.
        /// </summary>
        private const double InitialButtonDistance = 20.0;

        /// <summary>
        /// The initial button distance mode.
        /// </summary>
        private const DistanceMode InitialButtonDistanceMode = DistanceMode.TotalDistance;

        /// <summary>
        /// The initial outer radius.
        /// </summary>
        private const double InitialOuterRadius = InitialControlSize / 2 - InitialRingDistance;

        /// <summary>
        /// The initial inner radius.
        /// </summary>
        private const double InitialInnerRadius = InitialOuterRadius - InitialRingWidth;

        #endregion

        #region Fields & Properties

        #region ControlSize

        /// <summary>
        /// Width and Height of this control.
        /// </summary>
        public static readonly DependencyProperty ControlSizeProperty =
            DependencyProperty.Register(
                nameof(ControlSize),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialControlSize)
                {
                    PropertyChangedCallback = OnControlSizePropertyChanged,
                });

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>
        /// The size of the control.
        /// </value>
        /// <remarks>
        /// Shape of this control's bounding box needs to be squared, so Height and Width will be bound to this property.
        /// </remarks>
        public double ControlSize
        {
            get => (double)GetValue(ControlSizeProperty);
            set => SetValue(ControlSizeProperty, value);
        }

        #endregion

        #region RingDistance

        /// <summary>
        /// Distance from the ring to its bounding box.
        /// </summary>
        public static readonly DependencyProperty RingDistanceProperty =
            DependencyProperty.Register(
                nameof(RingDistance),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialRingDistance)
                {
                    PropertyChangedCallback = OnRingDistancePropertyPropertyChanged,
                });

        /// <summary>
        /// Gets or sets the distance from the ring to its bounding box.
        /// </summary>
        /// <value>
        /// The ring distance.
        /// </value>
        /// <remarks>
        /// Actually this is just padding, but i am afraid of strange interferences with standard behavior when using padding here, so i just use a new property for this.
        /// </remarks>
        public double RingDistance
        {
            get => (double)GetValue(RingDistanceProperty);
            set => SetValue(RingDistanceProperty, value);
        }

        #endregion

        #region RingWidth

        /// <summary>
        /// The ring width property.
        /// </summary>
        public static readonly DependencyProperty RingWidthProperty =
            DependencyProperty.Register(
                nameof(RingWidth),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialRingWidth)
                {
                    PropertyChangedCallback = OnRingWidthPropertyPropertyChanged,
                });

        /// <summary>
        /// Gets or sets the width of the ring.
        /// </summary>
        /// <value>
        /// The width of the ring.
        /// </value>
        /// <remarks>
        /// I.e. the distance from the ring's outer radius to its inner radius.
        /// </remarks>
        public double RingWidth
        {
            get => (double)GetValue(RingWidthProperty);
            set => SetValue(RingWidthProperty, value);
        }

        #endregion

        #region RingRotation

        /// <summary>
        /// The ring rotation property.
        /// </summary>
        public static readonly DependencyProperty RingRotationProperty =
            DependencyProperty.Register(
                nameof(RingRotation),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialRingRotation));

        /// <summary>
        /// Gets or sets the ring rotation.
        /// </summary>
        /// <value>
        /// The ring rotation.
        /// </value>
        /// <remarks>
        /// With the default rotation of <c>0</c>, the first button of this ring will be centered on top of the ring. The ring will rotate clockwise.
        /// </remarks>
        public double RingRotation
        {
            get => (double)GetValue(RingRotationProperty);
            set => SetValue(RingRotationProperty, value);
        }

        #endregion

        #region ButtonDistance

        /// <summary>
        /// The distance between buttons in degree.
        /// </summary>
        public static readonly DependencyProperty ButtonDistanceProperty =
            DependencyProperty.Register(
                nameof(ButtonDistance),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialButtonDistance));

        /// <summary>
        /// Gets or sets the button distance.
        /// </summary>
        /// <value>
        /// The button distance.
        /// </value>
        /// <remarks>
        /// Describes the distance between buttons of this ring in degrees. The <see cref="ButtonDistanceMode"/> determines,
        /// whether the distance specified here is used for every space between two adjacent buttons of shared equally between all spaces.
        /// </remarks>
        public double ButtonDistance
        {
            get => (double)GetValue(ButtonDistanceProperty);
            set => SetValue(ButtonDistanceProperty, value);
        }

        #endregion

        #region ButtonDistanceMode

        /// <summary>
        /// The button distance mode property.
        /// </summary>
        public static readonly DependencyProperty ButtonDistanceModeProperty =
            DependencyProperty.Register(
                nameof(ButtonDistanceMode),
                typeof(DistanceMode),
                typeof(ButtonRing),
                new PropertyMetadata(InitialButtonDistanceMode));

        /// <summary>
        /// Gets or sets the button distance mode.
        /// </summary>
        /// <value>
        /// The button distance mode.
        /// </value>
        public DistanceMode ButtonDistanceMode
        {
            get => (DistanceMode)GetValue(ButtonDistanceModeProperty);
            set => SetValue(ButtonDistanceModeProperty, value);
        }

        #endregion

        #region OuterRadius

        /// <summary>
        /// The outer radius property.
        /// </summary>
        public static readonly DependencyProperty OuterRadiusProperty =
            DependencyProperty.Register(
                nameof(OuterRadius),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialOuterRadius)
                {
                    PropertyChangedCallback = OnOuterRadiusChanged,
                    CoerceValueCallback = OnCoerceOuterRadiusProperty,
                });

        /// <summary>
        /// Gets the outer radius.
        /// </summary>
        /// <value>
        /// The outer radius.
        /// </value>
        public double OuterRadius => (double)GetValue(OuterRadiusProperty);

        #endregion

        #region InnerRadius

        /// <summary>
        /// The inner radius property.
        /// </summary>
        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register(
                nameof(InnerRadius),
                typeof(double),
                typeof(ButtonRing),
                new PropertyMetadata(InitialInnerRadius)
                {
                    CoerceValueCallback = OnCoerceInnerRadiusProperty,
                });

        /// <summary>
        /// Gets the inner radius.
        /// </summary>
        /// <value>
        /// The inner radius.
        /// </value>
        public double InnerRadius => (double)GetValue(InnerRadiusProperty);

        #endregion

        #region RotateContents

        /// <summary>
        /// The rotate contents property.
        /// </summary>
        public static readonly DependencyProperty RotateContentsProperty =
            DependencyProperty.Register(
                nameof(RotateContents),
                typeof(bool),
                typeof(ButtonRing),
                new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether the content of button ring items should be rotated along with the button.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the content of button ring items should be rotated; otherwise, <c>false</c>.
        /// </value>
        public bool RotateContents
        {
            get => (bool)GetValue(RotateContentsProperty);
            set => SetValue(RotateContentsProperty, value);
        }

        #endregion

        #endregion

        #region Types

        #region DistanceMode
        /// <summary>
        /// Enum to specify what the <see cref="ButtonRing.ButtonDistance"/> property means.
        /// </summary>
        public enum DistanceMode
        {
            /// <summary>
            /// <see cref="ButtonRing.ButtonDistance"/> describes the total sum of all spaces between all buttons of a ring.
            /// </summary>
            TotalDistance,

            /// <summary>
            /// <see cref="ButtonRing.ButtonDistance"/> describes the distance between each adjacent buttons in the ring.
            /// </summary>
            IndividualDistance,
        }
        #endregion

        #endregion

        #region Methods

        #region Event handlers

        #region OnControlSizePropertyChanged
        /// <summary>
        /// Called when [control size property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnControlSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjust outer radius.
            d.CoerceValue(OuterRadiusProperty);
        }
        #endregion

        #region OnRingDistancePropertyPropertyChanged
        /// <summary>
        /// Called when [ring distance property property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnRingDistancePropertyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjust outer radius.
            d.CoerceValue(OuterRadiusProperty);
        }
        #endregion

        #region OnRingWidthPropertyPropertyChanged
        /// <summary>
        /// Called when [ring width property property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnRingWidthPropertyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjust inner radius.
            d.CoerceValue(InnerRadiusProperty);
        }
        #endregion

        #region OnOuterRadiusChanged
        /// <summary>
        /// Called when [outer radius changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnOuterRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjust inner radius.
            d.CoerceValue(InnerRadiusProperty);
        }
        #endregion

        #region OnCoerceOuterRadiusProperty
        /// <summary>
        /// Called when [coerce outer radius property].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="baseValue">The base value.</param>
        /// <returns></returns>
        public static object OnCoerceOuterRadiusProperty(DependencyObject d, object baseValue)
        {
            double controlSize = (double)d.GetValue(ControlSizeProperty);
            double ringDistance = (double)d.GetValue(RingDistanceProperty);
            return Math.Max(0, controlSize / 2 - ringDistance);
        }
        #endregion

        #region OnCoerceInnerRadiusProperty
        /// <summary>
        /// Called when [coerce inner radius property].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="baseValue">The base value.</param>
        /// <returns></returns>
        public static object OnCoerceInnerRadiusProperty(DependencyObject d, object baseValue)
        {
            double outerRadius = (double)d.GetValue(OuterRadiusProperty);
            double ringWidth = (double)d.GetValue(RingWidthProperty);
            double result = Math.Max(0, outerRadius - ringWidth);
            return result;
        }
        #endregion

        #endregion

        #endregion
    }
}
