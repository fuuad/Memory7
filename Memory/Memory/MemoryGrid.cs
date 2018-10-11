using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Memory
{
    public class MemoryGrid
    {
        private Grid grid;
        private int cols;
        private int rows;
        bool allowclick = true;
        private int currentplayer;
        private int player1score = 0;
        private int player2score = 0;
        private int correctcount = 0;
        Label score1 = new Label();
        Label score2 = new Label();
        Label title = new Label();

        Image firstGuess;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            InitializeGameGrid(cols, rows);
            InitializeGameGrid(2 , 0);
            AddTitle();
            AddScores();
            AddImages();
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddTitle()
        {
            title.Content = "Memory";
            title.FontFamily = new FontFamily("Comic Sans");
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumnSpan(title, 7);
            Grid.SetColumn(title, cols);
            grid.Children.Add(title);
        }

        private void AddScores()
        {
            score1.Content = "Player 1 Score :" + player1score;
            score1.FontFamily = new FontFamily("Comic Sans");
            score1.FontSize = 20;
            score1.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumnSpan(score1, 7);
            Grid.SetColumn(score1, cols);
            Grid.SetRow(score1, 1);
            grid.Children.Add(score1);

            score2.Content = "Player 2 Score :" + player2score;
            score2.FontFamily = new FontFamily("Comic Sans");
            score2.FontSize = 20;
            score2.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumnSpan(score2, 7);
            Grid.SetColumn(score2, cols);
            Grid.SetRow(score2, 2);
            grid.Children.Add(score2);
        }


        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < (cols * rows); i++)
            {
                int imageNr = i % (cols * rows / 2) + 1;
                ImageSource source = new BitmapImage(new Uri("Icons/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }
            return images;
        }


        private async void AddImages()
        {
            List<ImageSource> images = GetImagesList();
            var rand = new Random();
            images = images.OrderBy(x => rand.Next()).ToList();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Tag = images.First();
                    ImageSource front = (ImageSource)backgroundImage.Tag;
                    backgroundImage.Source = front;
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                    await Task.Delay(500);
                    backgroundImage.Source = new BitmapImage(new Uri("Icons/question.png", UriKind.Relative));
                    allowclick = false;
                }
            }
            allowclick = true;
        }

        private async void CardClick(object sender, MouseButtonEventArgs e)
        {
            if (allowclick == true)
            {
                Image card = (Image)sender;
                ImageSource front = (ImageSource)card.Tag;
                card.Source = front;
                List<ImageSource> images = GetImagesList();

                if (firstGuess == null)
                {
                    firstGuess = card;
                    Console.WriteLine("First guess is set");
                    firstGuess.MouseDown -= new MouseButtonEventHandler(CardClick);
                    return;
                }
                if (card.Source.ToString() == firstGuess.Source.ToString() && card != firstGuess)
                {
                    //GOED GEKLIKT
                    correctcount += 2;
                    Console.WriteLine("Goedzo");
                    firstGuess.Opacity = 0.5;
                    card.Opacity = 0.5;
                    firstGuess.MouseDown -= new MouseButtonEventHandler(CardClick);
                    card.MouseDown -= new MouseButtonEventHandler(CardClick);
                    if (currentplayer == 0)
                    {
                        player1score++;
                        score1.Content = "Player 1 Score :" + player1score;
                    }
                    else
                    {
                        player2score++;
                        score2.Content = "Player 2 Score :" + player2score;
                    }
                    allowclick = true;
                }
                else
                {
                    if (currentplayer == 0)
                    {
                        currentplayer = 1;
                        Console.WriteLine("Player 2's turn");
                    }
                    else
                    {
                        currentplayer = 0;
                        Console.WriteLine("Player 2's turn");
                    }
                    allowclick = false;
                    Console.WriteLine("Niet goed");
                    await Task.Delay(1000);
                    firstGuess.Source = new BitmapImage(new Uri("Icons/question.png", UriKind.Relative));
                    card.Source = new BitmapImage(new Uri("Icons/question.png", UriKind.Relative));
                    allowclick = true;
                }
                if (correctcount == images.Count)
                {
                    if (player1score > player2score)
                    {
                        MessageBox.Show("Player 1 wins!");
                    }
                    else if (player1score < player2score)
                    {
                        MessageBox.Show("Player 2 wins!");
                    }
                    else {
                        MessageBox.Show("Draw!");
                    }
                }
                firstGuess.MouseDown += new MouseButtonEventHandler(CardClick);
                firstGuess = null;                
            }
        }
    }
}
