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


        /// <summary>
        /// een switch case die reageert wanneer de applicatiePage enum wordt veranderd en dan de pagina in de mainwindow <see cref="MainWindow.MainFrame"/> veranderd.
        /// </summary>
        /// <param name="value">wat de huidige pagina wordt</param>=
        /// <returns> de benodigde pagina</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicatiePage)value)
            {
                // Vindt de juiste pagina
                case ApplicatiePage.Hoofdmenu:
                    return new HoofdMenuPage();

                case ApplicatiePage.Newgame:
                    return new NewGamePage();

                case ApplicatiePage.Gameplay:
                    return new GamePlayPage();

                case ApplicatiePage.LoadGame:
                    return new LoadGamePage();

                case ApplicatiePage.Stats:
                    return new HighScorePage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// een overrideable method die de convertion terug draait.
        /// </summary>
        /// <param name="value"> waarde</param>
        /// <param name="targetType">wat je naar wilt converten</param>
        /// <param name="parameter"> wat je wilt gaan converten</param>
        /// <param name="culture"> informatie over omgeving</param>
        /// <returns></returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
