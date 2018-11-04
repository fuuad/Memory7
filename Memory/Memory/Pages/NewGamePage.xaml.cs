using System;
using System.Windows;
using System.Windows.Navigation;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class NewGamePage : BasePage<HoofdMenuViewModel>
    {
        /// <summary>
        /// private members
        /// </summary>
        bool overlayOpen = false;
        bool playerMode = true;
        bool playerDiff = true;
        App app = Application.Current as App;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NewGamePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// slaat input op voor speler1 naam.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextChangedP1(object sender, EventArgs e)
        {
            app.namePlayer1 = Player1.Text;
        }

        /// <summary>
        /// slaat input op voor speler2 naam.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextChangedP2(object sender, EventArgs e)
        {
            app.namePlayer2 = Player2.Text;
        }

        /// <summary>
        /// bij verandering van de waarde in de combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectThemeChange(object sender, EventArgs e)
        {
            app.currentTheme = Theme.SelectedValue.ToString();
            Console.WriteLine(app.currentTheme);
        }

        /// <summary>
        /// on options clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            overlayOpen = false;

            if (!overlayOpen)
            {
                SettingsOverlay.Visibility = Visibility.Visible;

                overlayOpen = !overlayOpen;
            }
            else
            {
                SettingsOverlay.Visibility = Visibility.Collapsed;

                overlayOpen = !overlayOpen;
            }
        }

        /// <summary>
        /// Zet de aantal spelers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player_Mode(object sender, RoutedEventArgs e)
        {
            if (playerMode)
            {
                playermode.Content = "Spelers: 2";
                playerMode = false;
            }
            else
            {
                playermode.Content = "Spelers: 1";
                playerMode = true;
            }
        }

        /// <summary>
        /// zet de moeilijksheidsgraad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Player_Diff(object sender, RoutedEventArgs e)
        {
            if (playerDiff)
            {
                difficulty.Content = "Moeilijksheidsgraad: Moeilijk";
                playerDiff = false;
            }
            else
            {
                difficulty.Content = "Moeilijksheidsgraad: Normaal";
                playerDiff = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).parentGrid.Visibility = Visibility.Visible;
        }
    }
}
