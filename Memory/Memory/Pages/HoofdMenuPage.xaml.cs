using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class HoofdMenuPage : BasePage<HoofdMenuViewModel>
    {
        bool overlayOpen = false;

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

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            overlayOpen = false;

            if (overlayOpen != true)
            {
                SettingsOverlay.Visibility = Visibility.Visible;
                overlayOpen = true;
            }
            else
            {
                SettingsOverlay.Visibility = Visibility.Collapsed;
                overlayOpen = false;
            }
        }

        private void Close_Game(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
