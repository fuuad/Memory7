using System.Windows;
using System.Windows.Input;

namespace Memory
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        private Window mWindow;

        #endregion


        #region Public Properties

        public ApplicatiePage CurrentPage { get; set; } = ApplicatiePage.Hoofdmenu;

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

        }

        #endregion

        #region Private Helpers

        #endregion
    }
}
