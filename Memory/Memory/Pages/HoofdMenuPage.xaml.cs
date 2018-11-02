using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class HoofdMenuPage : BasePage<HoofdMenuViewModel>
    {

        #region Constructors
        
        /// <summary>
        /// Standaard Constructor
        /// </summary>
        public HoofdMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public HoofdMenuPage(HoofdMenuViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        private void Options_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool overlayOpen = false;


            if (overlayOpen != true)
            {
                overlayOpen = true;

                SettingsOverlay.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsOverlay.Visibility = Visibility.Collapsed;
            }
        }
    }
}
