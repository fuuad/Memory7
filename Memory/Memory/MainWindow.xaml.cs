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
        SinglePlayerGame gridS;
        MultiPlayerGame gridM;
        Timer timerlab;
        Scores score;
        App app = Application.Current as App;

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
        /// pakt de opgeslagen naam input en zet ze in de labels
        /// </summary>
        public void SetNames()
        {
            Player1Label.Content = (object)app.namePlayer1;
            Player2Label.Content = (object)app.namePlayer2;
        }

        /// <summary>
        /// start spel voor enkele speler
        /// </summary>
        public void initGameGridSingle(bool diff)
        {
            score = new Scores(Score1Label, Player1Label);
            score = new Scores(Score2Label, Player2Label);
            gridS = new SinglePlayerGame(GameGrid, _cols, _rows, diff);
            timerlab = new Timer(TimerLabel);
            scoreBoard.Visibility = Visibility.Visible;
            SetNames();
        }

        /// <summary>
        /// start spel voor meerdere spelers
        /// </summary>        
        public void initGameGridMulti(bool diff)
        {
            score = new Scores(Score1Label, Player1Label);
            score = new Scores(Score2Label, Player2Label);
            gridM = new MultiPlayerGame(GameGrid, _cols, _rows, diff);
            timerlab = new Timer(TimerLabel);
            Scores.SetMulti(SinglePlayer);
            scoreBoard.Visibility = Visibility.Visible;
            SetNames();
        }
    }
}
