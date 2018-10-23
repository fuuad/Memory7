using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class HoofdMenuPage : BasePage
    {
        public HoofdMenuPage()
        {
            InitializeComponent();
        }

        private void NewGame()
        {
            //grid = new MemoryGrid(GameGrid, NR_OF_ROWS, NR_OF_COLS);
        }

        /// <summary>
        /// Functionaliteit voor wanneer er op start game gedrukt wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// Functionaliteit voor wanneer er op Game Laden gedrukt wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Functionaliteit voor wanneer er op Opties gedrukt wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Functionaliteit voor wanneer er op statistieken gedrukt wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stats_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Functionaliteit voor wanneer er op Afsluiten gedrukt wordt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
