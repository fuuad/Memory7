﻿using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class HighScorePage : BasePage<HoofdMenuViewModel>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HighScorePage()
        {
            InitializeComponent();
        }

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
