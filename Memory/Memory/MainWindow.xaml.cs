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
        #endregion

        #region public properties

        public ApplicatiePage CurrentPage { get; set; } = ApplicatiePage.Hoofdmenu;

        #endregion

        
    }

}
