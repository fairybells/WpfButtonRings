using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Fairybells.WpfButtonRings
{
    /// <summary>
    /// Value converter to perform several trigonometric calculations needed for the <see cref="ButtonRing"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Actually, this is multiple converters united in one, hence the <see cref="ConverterOperation"/>.
    /// </para>
    /// </remarks>
    public class ButtonRingMultiValueConverter : IMultiValueConverter
    {
        #region Fields & Properties

        #endregion

        #region Types

        #region ConverterOperation
        /// <summary>
        /// Type of the conversion operation.
        /// </summary>
        public enum ConverterOperation
        {
            /// <summary>
            /// Get the rotation of a button of this ring.
            /// </summary>
            GetRotation,

            /// <summary>
            /// The get content rotation.
            /// </summary>
            GetContentRotation,

            /// <summary>
            /// Get the first triangle point.
            /// </summary>
            GetFirstTrianglePoint,

            /// <summary>
            /// Get the second triangle point.
            /// </summary>
            GetSecondTrianglePoint,

            /// <summary>
            /// Add all values.
            /// </summary>
            AddValues,

            /// <summary>
            /// Divide the first value by all other values.
            /// </summary>
            DivideValues,
        }
        #endregion

        #endregion

        #region Methods

        #region IMultiValueConverter implementation

        #region Convert
        /// <summary>
        /// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.
        /// If the method returns <see langword="null" />, the valid <see langword="null" /> value is used.
        /// A return value of <see cref="T:System.Windows.DependencyProperty" />.<see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is available, or else will use the default value.
        /// A return value of <see cref="T:System.Windows.Data.Binding" />.<see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Value #0 should always be bound to the ItemsSource property; Value #1 should always be bound to the Items property as fallback if there is no ItemsSource.
        /// </para>
        /// <para>
        /// When calculating the rotation, value #2 should be the item control itself.
        /// </para>
        /// <para>
        /// When calculating a triangle point, value #2 and value #3 should be the outer radius and the ring distance, respectively.
        /// Value #4 should be bound to the button distance; value #5 should be bound to the distance type.
        /// </para>
        /// </remarks>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Determine the operation to perform and delegate to respective utility method.
            ConverterOperation operation = (ConverterOperation)parameter;
            switch (operation)
            {
                case ConverterOperation.GetRotation: return CalculateRotation(values);
                case ConverterOperation.GetContentRotation: return CalculateContentRotation(values);
                case ConverterOperation.GetFirstTrianglePoint: return CalculateTrianglePoint(true, values);
                case ConverterOperation.GetSecondTrianglePoint: return CalculateTrianglePoint(false, values);
                case ConverterOperation.AddValues: return CalculateArithmeticOperation(values, (x1, x2) => x1 + x2);
                case ConverterOperation.DivideValues: return CalculateArithmeticOperation(values, (x1, x2) => x1 / x2);
            }

            return null;
        }
        #endregion

        #region ConvertBack
        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Utility methods

        #region CalculateRotation
        /// <summary>
        /// Calculates the rotation of a button in the ring.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private double CalculateRotation(object[] values)
        {
            // Get collection view.
            CollectionView collectionView = GetCollectionView(values);
            if (collectionView == null)
            {
                return 0.0;
            }
            // Get index of current item.
            int index = GetIndex(collectionView, values);

            // Calculate rotation.
            double result =
                (collectionView.Count == 0)
                    ? 0.0
                    : (360.0 * index / collectionView.Count);

            return result;
        }
        #endregion

        #region CalculateContentRotation
        /// <summary>
        /// Calculates the content rotation.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private double CalculateContentRotation(object[] values)
        {
            double itemRotation = CalculateRotation(values);
            double ringRotation = (values[3] as double?) ?? 0.0;

            double result =
                -itemRotation - ringRotation;

            return result;
        }
        #endregion

        #region CalculateTrianglePoint
        /// <summary>
        /// Calculates the triangle point.
        /// </summary>
        /// <param name="isFirstPoint">if set to <c>true</c> [is first point].</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <remarks>
        /// To get the shape of a ring segment, a ring shape is intersected with a triangle.
        /// One point of this triangle is the origin of the ring, the other two points are being calculated with this method.
        /// </remarks>
        private System.Windows.Point CalculateTrianglePoint(bool isFirstPoint, object[] values)
        {
            // Get collection view.
            CollectionView collectionView = GetCollectionView(values);
            if ((collectionView == null) || collectionView.Count < 2)
            {
                return new System.Windows.Point();
            }

            // Extract relevant values.
            double radius = ((double)values[2]) + ((double)values[3]);
            double buttonDistance = (double)values[4];
            ButtonRing.DistanceMode distanceMode = (ButtonRing.DistanceMode)values[5];

            // Calculate total arc angle (in degrees).
            double angle =
                (distanceMode == ButtonRing.DistanceMode.TotalDistance)
                    ? ((360.0 - buttonDistance) / collectionView.Count)
                    : ((360.0 / collectionView.Count) - buttonDistance);
            // Take half this angle and convert to Radiant.
            angle = Math.PI * angle / 360.0;
            // Calculate x-value of resulting point.
            int x = (int)Math.Round(radius * Math.Sin(angle) / Math.Cos(angle));
            // y-value is just the negative radius.
            int y = (int)Math.Round(-radius);

            System.Windows.Point result =
                isFirstPoint
                    ? new System.Windows.Point(-x, y)
                    : new System.Windows.Point(x, y);
            return result;
        }
        #endregion

        #region GetCollectionView
        /// <summary>
        /// Gets the collection view.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private CollectionView GetCollectionView(object[] values)
        {
            CollectionView result =
                (values[0] as CollectionView) ?? (values[1] as CollectionView);
            return result;
        }
        #endregion

        #region GetIndex
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="collectionView">The collection view.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        private int GetIndex(CollectionView collectionView, object[] values)
        {
            return collectionView.IndexOf(values[2]);
        }
        #endregion

        #region CalculateArithmeticOperation
        /// <summary>
        /// Calculates the arithmetic operation.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        private double CalculateArithmeticOperation(object[] values, Func<double, double, double> operation)
        {
            // Make sure there are any operands.
            if (values.Length == 0)
            {
                // Nothing to do.
                return 0.0;
            }

            // Make sure the first operand is a double.
            if (!(values[0] is double result))
            {
                // Return default value.
                return 0.0;
            }

            // Aggregate all other double operands with the first one using the specified operation.
            result = values.Skip(1).OfType<double>().Aggregate(result, operation);

            return result;
        } 
        #endregion

        #endregion

        #endregion
    }
}
