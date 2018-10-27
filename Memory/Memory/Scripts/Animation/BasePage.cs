using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;

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

        #endregion

        #region public properties
        // animatie onload
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideFromRight;

        // animatie unload
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideToLeft;

        // lengte animatie
        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel {
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

        public BasePage()
        {
            // animatie bij hide.
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //check of pagina geladen is
            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load / Unload

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //animeert de pagina inkomend.
            await AnimateIn();
        }

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
