﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.IO;

namespace Memory
{
    /// <summary>
    /// Script voor de memory kaarten
    /// </summary>
    public class MemoryGrid
    {
        #region private members

        private Grid grid;
        private int cols;
        private int rows;
        private bool allowclick = true;
        private int currentplayer = 0;
        private int player1score = 0;
        private int player2score = 0;
        private int correctcount = 0;
        private string theme;
        private Label score1 = new Label();
        private Label score2 = new Label();
        private MediaPlayer Sound1 = new MediaPlayer();
        private MediaPlayer Sound2 = new MediaPlayer();
        private MediaPlayer Sound3 = new MediaPlayer();
        private Image firstGuess;
        private String[] directories = Directory.GetDirectories("Assets/Themes/");
        private String[] files;

        #endregion
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="grid">Het grid waar de kaarten in komen</param>
        /// <param name="cols"> hoeveel kolommen het grid krijgt</param>
        /// <param name="rows"> hoeveel rijen het grid krijgt</param>
        public MemoryGrid(Grid grid, int cols, int rows)
        {
            theme = Microsoft.VisualBasic.Interaction.InputBox("Welk Thema wil je? Default of Warcraft?", "Vraagje");

            if(theme != string.Empty)
            {
                this.grid = grid;
                this.cols = cols;
                this.rows = rows;

                InitializeGameGrid(cols, rows);
                GetImagesList();
                AddImages();
                SetBackground();
                Scores.SetScore((string)player1score.ToString(), 1);
                Scores.SetScore((string)player2score.ToString(), 2);
                Scores.SetPlayerTurn(currentplayer);
            }
        }
        /// <summary>
        /// verandert de achtergrond en muziek van het spel afhankelijk van gekozen thema.
        /// </summary>
        private void SetBackground()
        {
            ImageBrush myBrush = new ImageBrush();
            switch (theme)
            {
                case "Default":
                    myBrush.ImageSource = new BitmapImage(new Uri("Assets/Themes/Default/Assets/background.png", UriKind.Relative));
                    Sound3.Volume = 0.1;
                    Sound3.Open((new Uri("Assets/Themes/Default/Audio/background.mp3", UriKind.Relative)));
                    Sound3.Play();
                    Sound3.MediaEnded += new EventHandler(Media_Ended);
                    break;
                case "Warcraft":
                    myBrush.ImageSource = new BitmapImage(new Uri("Assets/Themes/Warcraft/Assets/background.png", UriKind.Relative));
                    Sound3.Volume = 0.05;
                    Sound3.Open((new Uri("Assets/Themes/Warcraft/Audio/background.mp3", UriKind.Relative)));
                    Sound3.Play();
                    Sound3.MediaEnded += new EventHandler(Media_Ended);
                    break;
                default:
                    myBrush.ImageSource = new BitmapImage(new Uri("Assets/Themes/Default/Assets/background.png", UriKind.Relative));
                    Sound3.Volume = 0.1;
                    Sound3.Open((new Uri("Assets/Themes/Default/Audio/background.mp3", UriKind.Relative)));
                    Sound3.Play();
                    Sound3.MediaEnded += new EventHandler(Media_Ended);
                    break;
            }
            Grid parentGrid = (Grid)VisualTreeHelper.GetParent(grid);
            parentGrid.Background = myBrush;
        }

        /// <summary>
        /// Zodra muziek afloopt replay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            Sound3.Position = TimeSpan.Zero;
            Sound3.Play();
        }

        /// <summary>
        /// maakt het grid aan
        /// </summary>
        /// <param name="cols">hoeveel kolommen er moeten komen</param>
        /// <param name="rows">hoeveel rijen er moeten komen</param>
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

        List<ImageSource> images = new List<ImageSource>();

        /// <summary>
        /// pakt de images uit het gekozen thema en plaatst die in een lijst.
        /// </summary>
        /// <returns></returns>
        private List<ImageSource> GetImagesList()
        {
            switch (theme)
            {
                case "Default":
                    files = Directory.GetFiles("Assets/Themes/Default/Front/", "*.png");
                    break;
                case "Warcraft":
                    files = Directory.GetFiles("Assets/Themes/Warcraft/Front/", "*.png");
                    break;
                default:
                    files = Directory.GetFiles("Assets/Themes/Default/Front/", "*.png");
                    break;
            }
            
            for (int i = 0; i < files.Length; i++)
            {
                ImageSource source = new BitmapImage(new Uri(files[i], UriKind.Relative));
                images.Add(source);
            }
            var rand = new Random();
            images = images.OrderBy(x => rand.Next()).ToList();
            if (files.Length > cols * rows / 2)
            {
                images.RemoveRange(cols * rows / 2, images.Count - cols * rows / 2);
            }
            images = images.Concat(images).ToList();
            return images;
        }

        /// <summary>
        /// voegt de images toe aan het game grid
        /// </summary>
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
                    //ImageSource front = (ImageSource)backgroundImage.Tag;
                    //backgroundImage.Source = front;
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                    //await Task.Delay(500);
                    backgroundImage.Source = new BitmapImage(new Uri("Assets/Themes/Warcraft/Back/question.png", UriKind.Relative));
                    allowclick = false;
                }
            }
            allowclick = true;
            Timer.StartTimer();
        }

        /// <summary>
        /// houdt de klik actie bij van de user wanneer die op een plaatje klikt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CardClick(object sender, MouseButtonEventArgs e)
        {
            if (allowclick == true)
            {
                Sound1.Open((new Uri("Assets/Themes/Warcraft/Audio/click.wav", UriKind.Relative)));
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
                    Sound2.Open((new Uri("Assets/Themes/Warcraft/Audio/matched.wav", UriKind.Relative)));
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
                        score1.Content = player1score;
                        Scores.SetScore((string)score1.Content.ToString(), 1);
                    }
                    else
                    {
                        player2score++;
                        score2.Content = player2score;
                        Scores.SetScore((string)score2.Content.ToString(), 2);
                        Scores.SetPlayerTurn(currentplayer);
                    }
                    allowclick = true;
                }
                else
                {
                    //FOUT GEKLIKT
                    if (currentplayer == 0)
                    {
                        
                        currentplayer = 1;
                        Scores.SetPlayerTurn(currentplayer);
                        Console.WriteLine("Player 2's turn");
                    }
                    else
                    {
                       
                        currentplayer = 0;
                        Scores.SetPlayerTurn(currentplayer);
                        Console.WriteLine("Player 1's turn");
                    }
                    allowclick = false;
                    Console.WriteLine("Niet goed");
                    await Task.Delay(1000);
                    firstGuess.Source = new BitmapImage(new Uri("Assets/Themes/Warcraft/Back/question.png", UriKind.Relative));
                    card.Source = new BitmapImage(new Uri("Assets/Themes/Warcraft/Back/question.png", UriKind.Relative));
                    firstGuess.MouseDown += new MouseButtonEventHandler(CardClick);
                    allowclick = true;
                }
                if (correctcount == images.Count)
                {
                    Timer.StopTimer();
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
