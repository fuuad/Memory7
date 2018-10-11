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
using System.IO;

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
        MediaPlayer Sound1 = new MediaPlayer();
        MediaPlayer Sound2 = new MediaPlayer();
        MediaPlayer Sound3 = new MediaPlayer();
        Image firstGuess;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            InitializeGameGrid(cols, rows);
            InitializeGameGrid(1, 0);
            AddTitle();
            AddScores();
            GetImagesList();
            AddImages();
            Sound3.Volume = 0.05;
            Sound3.Open((new Uri("Audio/background2.mp3", UriKind.Relative)));
            Sound3.Play();
            Sound3.MediaEnded += new EventHandler(Media_Ended);
            setBackground();
        }

        private void setBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("Images/background2.png", UriKind.Relative));
            grid.Background = myBrush;
        }
        private void Media_Ended(object sender, EventArgs e)
        {
            Sound3.Position = TimeSpan.Zero;
            Sound3.Play();
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
            Label title = new Label();
            title.Content = "Memory";
            title.Foreground = Brushes.White;
            title.HorizontalAlignment = HorizontalAlignment.Stretch;
            title.VerticalAlignment = VerticalAlignment.Stretch;
            title.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            title.VerticalAlignment = VerticalAlignment.Stretch;

            Viewbox vb = new Viewbox();
            vb.HorizontalAlignment = HorizontalAlignment.Stretch;
            vb.Child = title;
            Grid.SetRow(vb, 0);
            Grid.SetColumn(vb, cols);
            grid.Children.Add(vb);
        }

        private void AddScores()
        {
            score1.Content = "Player 1 Score :" + " " + player1score;
            score1.FontFamily = new FontFamily("Comic Sans");
            score1.Foreground = Brushes.White;
            score1.HorizontalAlignment = HorizontalAlignment.Stretch;
            score1.VerticalAlignment = VerticalAlignment.Stretch;
            score1.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            score1.VerticalAlignment = VerticalAlignment.Stretch;

            Viewbox vb = new Viewbox();
            vb.HorizontalAlignment = HorizontalAlignment.Stretch;
            vb.Child = score1;
            Grid.SetRow(vb, 1);
            Grid.SetColumn(vb, cols);
            grid.Children.Add(vb);

            score2.Content = "Player 2 Score :" + " " + player2score;
            score2.FontFamily = new FontFamily("Comic Sans");
            score2.Foreground = Brushes.White;
            score2.HorizontalAlignment = HorizontalAlignment.Stretch;
            score2.VerticalAlignment = VerticalAlignment.Stretch;
            score2.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            score2.VerticalAlignment = VerticalAlignment.Stretch;

            Viewbox vb2 = new Viewbox();
            vb2.HorizontalAlignment = HorizontalAlignment.Stretch;
            vb2.Child = score2;
            Grid.SetRow(vb2, 2);
            Grid.SetColumn(vb2, cols);
            grid.Children.Add(vb2);
        }

        List<ImageSource> images = new List<ImageSource>();

        private List<ImageSource> GetImagesList()
        {
            String[] files = Directory.GetFiles("Icons/", "*.png");
            
            for (int i = 1; i < files.Length; i++)
            {
                ImageSource source = new BitmapImage(new Uri(files[i], UriKind.Relative));
                images.Add(source);
            }
            var rand = new Random();
            images = images.OrderBy(x => rand.Next()).ToList();
            images.RemoveRange(cols * rows / 2 - 1, images.Count - cols * rows / 2);

            images = images.Concat(images).ToList();
            return images;
        }


        private async void AddImages()
        {
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
                    backgroundImage.Source = new BitmapImage(new Uri("Images/question.png", UriKind.Relative));
                    allowclick = false;
                }
            }
            allowclick = true;
        }

        private async void CardClick(object sender, MouseButtonEventArgs e)
        {
            if (allowclick == true)
            {
                Sound1.Open((new Uri("Audio/click.wav", UriKind.Relative)));
                Sound1.Play();

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
                    Sound2.Volume = 0.3;
                    Sound2.Open((new Uri("Audio/matched.wav", UriKind.Relative)));
                    Sound2.Play();
                    correctcount += 2;
                    Console.WriteLine("Goedzo");
                    firstGuess.Opacity = 0.5;
                    card.Opacity = 0.5;
                    firstGuess.MouseDown -= new MouseButtonEventHandler(CardClick);
                    card.MouseDown -= new MouseButtonEventHandler(CardClick);
                    if (currentplayer == 0)
                    {
                        player1score++;
                        score1.Content = "Player 1 Score :" + " " + player1score;
                    }
                    else
                    {
                        player2score++;
                        score2.Content = "Player 2 Score :" + " " + player2score;
                    }
                    allowclick = true;
                }
                else
                {
                    //FOUT GEKLIKT
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
                    firstGuess.Source = new BitmapImage(new Uri("Images/question.png", UriKind.Relative));
                    card.Source = new BitmapImage(new Uri("Images/question.png", UriKind.Relative));
                    firstGuess.MouseDown += new MouseButtonEventHandler(CardClick);
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
                    else
                    {
                        MessageBox.Show("Draw!");
                    }
                }
                firstGuess = null;
            }
        }
    }
}
