using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Memory
{
    /// <summary>
    /// The View Model for the HoofdMenu
    /// </summary>
    public class HoofdMenuViewModel : BaseViewModel
    {
        #region Private Member



        #endregion


        #region Public Properties
        
        public string StartButton { get; set; }

        #endregion

        #region Commands

        public ICommand NewCommand { get; set; }

        public ICommand LoadCommand { get; set; }

        public ICommand ScoreCommand { get; set; }

        public ICommand SettingsCommand { get; set; }

        public ICommand QuitCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HoofdMenuViewModel()
        {
            NewCommand = new RelayCommand(async () => await NewGame());

            LoadCommand = new RelayCommand(async () => await LoadGame());

            ScoreCommand = new RelayCommand(async () => await OpenScore());

            SettingsCommand = new RelayCommand(async () => await OpenSettings());

            QuitCommand = new RelayCommand(async () => await QuitGame());
        }
        #endregion


        public async Task NewGame()
        {
            await Task.Delay(500);
            Console.WriteLine("NewGameClicked");
        }

        public async Task LoadGame()
        {
            await Task.Delay(500);
            Console.WriteLine("LoadGameClicked");
        }

        public async Task OpenScore()
        {
            await Task.Delay(500);
            Console.WriteLine("OpenScoreClicked");
        }

        public async Task OpenSettings()
        {
            await Task.Delay(500);
            Console.WriteLine("OpenSettingsClicked");
        }

        public async Task QuitGame()
        {
            await Task.Delay(500);
            Console.WriteLine("QuitGameClicked");
        }

    }
}
