using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    /// <summary>
    /// Converteert de <see cref="ApplicatiePage" /> naar een echte pagina
    /// </summary>
    public class ApplicatiePageValueConverter : BaseValueConverter<ApplicatiePageValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicatiePage)value)
            {
                // Vindt de juiste pagina
                case ApplicatiePage.Hoofdmenu:
                    return new HoofdMenuPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
