using System.Windows;
using System.Windows.Input;

namespace Memory
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// de applicatie window.
        /// </summary>
        private Window mWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// Geeft aan huidig zichtbare pagina in de applicatie
        /// </summary>
        public ApplicatiePage CurrentPage { get; set; } = ApplicatiePage.Hoofdmenu;

        #endregion

        #region Constructor

        /// <summary>
        /// Standaard constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
        }

        #endregion
    }
}
