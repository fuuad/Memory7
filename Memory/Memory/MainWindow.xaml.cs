using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _rows = 4;
        int _cols = 4;
        MemoryGrid grid;
        Timer timerlab;
        Scores score1;
        Scores score2;

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

        /// <summary>
        /// start game
        /// </summary>
        public void initGameGrid()
        {
            scoreBoard.Visibility = Visibility.Visible;
            score1 = new Scores(Score1Label, Player1Label);
            score2 = new Scores(Score2Label, Player2Label);
            grid = new MemoryGrid(GameGrid, _cols, _rows);
            timerlab = new Timer(TimerLabel);

        }
    }
}
