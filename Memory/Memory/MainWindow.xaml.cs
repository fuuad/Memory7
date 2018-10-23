using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int NR_OF_COLS = 4;
        private int NR_OF_ROWS = 4;
        MemoryGrid grid;

        #region Constructor

        /// <summary>
        /// Standaard Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }
        
        #endregion

        #region methods

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

        #endregion

        #region public properties

        public ApplicatiePage CurrentPage { get; set; } = ApplicatiePage.Hoofdmenu;

        #endregion

        
    }

}
