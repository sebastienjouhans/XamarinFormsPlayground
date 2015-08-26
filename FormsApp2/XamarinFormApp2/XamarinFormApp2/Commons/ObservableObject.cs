
namespace XamarinFormApp2.Commons
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs after a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// Extracts the name of a property from an expression.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="propertyExpression">An expression returning the property's name.</param>
        /// <returns>The name of the property returned by the expression.</returns>
        /// <exception cref="ArgumentNullException">If the expression is null.</exception>
        /// <exception cref="ArgumentException">If the expression does not represent a property.</exception>
        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var body = propertyExpression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException(@"Invalid argument", "propertyExpression");
            }

            var property = body.Member as PropertyInfo;

            if (property == null)
            {
                throw new ArgumentException(@"Argument is not a property", "propertyExpression");
            }

            return property.Name;
        }

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property.</param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                var propertyName = GetPropertyName(propertyExpression);
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Sets the specified field to a new value and raises PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property.</param>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns><c>true</c> if the fields value has changed, <c>false</c> otherwise.</returns>
        protected bool Set<T>(Expression<Func<T>> propertyExpression, ref T field, T newValue)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            this.RaisePropertyChanged(propertyExpression);
            return true;
        }

        #endregion Methods
    }
}
