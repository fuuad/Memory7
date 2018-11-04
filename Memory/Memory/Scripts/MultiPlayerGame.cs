using System;
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
    public class MultiPlayerGame
    {
        #region private members

        private Grid _grid;
        private int _cols;
        private int _rows;
        private bool _diff;
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
        private List<ImageSource> images = new List<ImageSource>();
        private String[] directories = Directory.GetDirectories("Assets/Themes/");
        private String[] files;
        private MessageBoxResult dialogResult;

        App app = Application.Current as App;

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="grid">Het grid waar de kaarten in komen</param>
        /// <param name="cols"> hoeveel kolommen het grid krijgt</param>
        /// <param name="rows"> hoeveel rijen het grid krijgt</param>
        /// <param name="diff"> of alle kaartjes in 1x geladen kunnen worden</param>
        public MultiPlayerGame(Grid grid, int cols, int rows, bool diff)
        {
            theme = app.currentTheme;

            _diff = diff;

            if (theme != string.Empty)
            {
                _grid = grid;
                _cols = cols;
                _rows = rows;

                SetGameGrid(_cols, _rows);
                GetImagesList();
                AddImages();
                SetBackground();
                Scores.SetScore((string)player1score.ToString(), 1);
                Scores.SetScore((string)player2score.ToString(), 2);
                Scores.SetPlayerTurn(currentplayer);
            }
            else
            {
                ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Newgame;
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
                case "System.Windows.Controls.ComboBoxItem: Default":
                    myBrush.ImageSource = new BitmapImage(new Uri("Assets/Themes/Default/Assets/background.png", UriKind.Relative));
                    Sound3.Volume = 0.1;
                    Sound3.Open((new Uri("Assets/Themes/Default/Audio/background.mp3", UriKind.Relative)));
                    Sound3.Play();
                    Sound3.MediaEnded += new EventHandler(Media_Ended);
                    break;
                case "System.Windows.Controls.ComboBoxItem: Warcraft":
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
            Grid parentGrid = (Grid)VisualTreeHelper.GetParent(_grid);
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
        /// set informatie aan het GameGrid.
        /// </summary>
        /// <param name="_cols">hoeveel kolommen er moeten komen</param>
        /// <param name="_rows">hoeveel rijen er moeten komen</param>
        private void SetGameGrid(int _cols, int _rows)
        {
            for (int i = 0; i < _rows; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < _cols; i++)
            {
                _grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        /// <summary>
        /// refresht de informatie aan het GameGrid.
        /// </summary>
        private void ResetGameGrid()
        {
            Timer.Resetbutton();
            _grid.Children.Clear();
            _grid.RowDefinitions.Clear();
            _grid.ColumnDefinitions.Clear();
            images.Clear();
            currentplayer = 0;
            player1score = 0;
            player2score = 0;
            correctcount = 0;
            Scores.SetScore((string)player1score.ToString(), 1);
            Scores.SetScore((string)player2score.ToString(), 2);
            Scores.SetPlayerTurn(currentplayer);
        }

        /// <summary>
        /// pakt de images uit het gekozen thema en plaatst die in een lijst.
        /// </summary>
        /// <returns></returns>
        private List<ImageSource> GetImagesList()
        {
            switch (theme)
            {
                case "System.Windows.Controls.ComboBoxItem: Default":
                    files = Directory.GetFiles("Assets/Themes/Default/Front/", "*.png");
                    break;
                case "System.Windows.Controls.ComboBoxItem: Warcraft":
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
            if (files.Length > _cols * _rows / 2)
            {
                images.RemoveRange(_cols * _rows / 2, images.Count - _cols * _rows / 2);
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

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _cols; column++)
                {
                    if(!_diff)
                    {
                        Image backgroundImage = new Image();
                        backgroundImage.Tag = images.First();
                        images.RemoveAt(0);
                        backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroundImage, column);
                        Grid.SetRow(backgroundImage, row);
                        _grid.Children.Add(backgroundImage);
                        backgroundImage.Source = new BitmapImage(new Uri("Assets/Themes/Warcraft/Back/question.png", UriKind.Relative));
                        allowclick = false;
                    }
                    else
                    {
                        Image backgroundImage = new Image();
                        backgroundImage.Tag = images.First();
                        ImageSource front = (ImageSource)backgroundImage.Tag;
                        backgroundImage.Source = front;
                        images.RemoveAt(0);
                        backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                        Grid.SetColumn(backgroundImage, column);
                        Grid.SetRow(backgroundImage, row);
                        _grid.Children.Add(backgroundImage);
                        await Task.Delay(500);
                        backgroundImage.Source = new BitmapImage(new Uri("Assets/Themes/Warcraft/Back/question.png", UriKind.Relative));
                        allowclick = false;
                    }
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
                        MessageBox.Show(app.namePlayer1 + " heeft gewonnen!");
                    }
                    else if (player1score < player2score)
                    {
                        MessageBox.Show(app.namePlayer2 + " heeft gewonnen!");
                    }
                    else
                    {
                        MessageBox.Show(app.namePlayer1 + " tegen " + app.namePlayer2 + " is geëindigd in een gelijk spel.");
                    }

                    dialogResult = MessageBox.Show("Wil je het spel herstarten met dezelfde instellingen?", "Vraagje", MessageBoxButton.YesNo);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        ResetGameGrid();
                        SetGameGrid(_cols, _rows);
                        GetImagesList();
                        AddImages();
                    }
                    else if (dialogResult == MessageBoxResult.No)
                    {
                        Grid parentGrid = (Grid)VisualTreeHelper.GetParent(_grid);
                        parentGrid.Visibility = Visibility.Collapsed;
                        Sound3.Stop();
                        ResetGameGrid();
                        ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Hoofdmenu;
                    }
                }
                firstGuess = null;
            }
        }
    }
}
