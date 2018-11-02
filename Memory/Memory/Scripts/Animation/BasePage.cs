using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;

namespace Memory
{
    /// <summary>
    /// Een pagina waar alle paginas van gaan functioneren.
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region private members

        private VM mViewModel;

        private HoofdMenuViewModel specificViewModel;

        #endregion

        #region public properties

        /// <summary>
        /// /// animatie onload
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideFromRight;

        /// <summary>
        /// animatie unload
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideToLeft;

        /// <summary>
        /// lengte animatie
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;


        /// <summary>
        /// set de juiste viewmodel per pagina.
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// standaard constructor die animaties runt wanneer een pagina geladen wordt.
        /// </summary>
        public BasePage()
        {
            // animatie bij hide.
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //check of pagina geladen is
            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        /// <summary>
        /// Constructor die animaties specifiek maakt voor viewmodel.
        /// </summary>
        /// <param name="specificViewModel"></param>
        public BasePage(HoofdMenuViewModel specificViewModel)
        {
            this.specificViewModel = specificViewModel;
        }

        #endregion

        #region Animation Load / Unload
        /// <summary>
        /// zodra de pagina geladen is animate de pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //animeert de pagina inkomend.
            await AnimateIn();
        }

        /// <summary>
        /// de animatie voor een inkomende pagina
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideFromRight:

                    await this.SlideAndFadeFromRight(this.SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// de animatie voor een verlaten pagina
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideToLeft:

                    await this.SlideAndFadeFromRight(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
