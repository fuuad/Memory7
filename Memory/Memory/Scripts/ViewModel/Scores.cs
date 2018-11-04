using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Memory
{
    class Scores
    {
        /// <summary>
        /// Private members voor scores
        /// </summary>
        public static Label _lab;
        public static Label _lab2;
        public static Label player1Lab;
        public static Label player2Lab;
        
        /// <summary>
        /// default constructor 
        /// </summary>
        /// <param name="lab"></param>
        /// <param name="player"></param>
        public Scores(Label lab, Label player)
        {
            if(lab.Name == "Score1Label")
            {
                _lab = lab;
                player1Lab = player;
            }
            else
            {
                _lab2 = lab;
                player2Lab = player;
            }
        }

        /// <summary>
        /// toont de player 2 scores bij multiplayer.
        /// </summary>
        /// <param name="panel"></param>
        public static void SetMulti(StackPanel panel)
        {
            panel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// set scores vanuit memorygrid script
        /// </summary>
        /// <param name="str"></param>
        /// <param name="player"></param>
        public static void SetScore(string str, int player)
        {
            if (player == 1)
            {
                _lab.Content = str;
            }
            else
            {
                _lab2.Content = str;
            }
        }

        /// <summary>
        /// set playerturn vanuit memorygrid script
        /// </summary>
        /// <param name="turn"></param>
        public static void SetPlayerTurn(int turn)
        {
            if(turn == 0)
            {
                _lab.Background = new SolidColorBrush(Colors.LightBlue);
                _lab2.Background = new SolidColorBrush(Colors.DarkGray);
                player1Lab.Background = new SolidColorBrush(Colors.LightBlue);
                player2Lab.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                _lab2.Background = new SolidColorBrush(Colors.LightBlue);
                _lab.Background = new SolidColorBrush(Colors.DarkGray);
                player2Lab.Background = new SolidColorBrush(Colors.LightBlue);
                player1Lab.Background = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }
}
