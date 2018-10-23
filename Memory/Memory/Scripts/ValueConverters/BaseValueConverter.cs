using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Memory
{
    /// <summary>
    /// Direct gelinkt aan xaml
    /// </summary>
    /// <typeparam name="T">Het type dat wordt geconverteert</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        private static T mConverter = null;

        #endregion

        #region Markup Methods
        /// <summary>
        /// Zorgt dat er maar 1 statische converter aanwezig is in het programma
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>new instance als niet bestaats</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
        #endregion

        #region converteer methods

        /// <summary>
        /// De methode om types te converteren
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// De methode om originele type terug te halen
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
