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
        #region commands

        /// <summary>
        /// Command om naar new page te switchen
        /// </summary>
        public ICommand NewGamePageCommand { get; set; }


        /// <summary>
        /// command om naar gameplay page te switchen
        /// </summary>
        public ICommand GameplayPageCommand { get; set; }

        /// <summary>
        /// command om naar loadgame page te switchen
        /// </summary>
        public ICommand LoadGamePageCommand { get; set; }

        /// <summary>
        /// command om naar de statistieken page te switchen
        /// </summary>
        public ICommand ScoreCommand { get; set; }

        /// <summary>
        /// command om naar de hoofdmenu page te switchen
        /// </summary>
        public ICommand HoofdMenuCommand { get; set; }

        /// <summary>
        /// command om naar de settings page te switchen
        /// </summary>
        public ICommand SettingsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Standaard Constructor
        /// </summary>
        public HoofdMenuViewModel()
        {

            NewGamePageCommand = new RelayCommand(async () => await SwitchToNewGamePage());

            GameplayPageCommand = new RelayCommand(async () => await SwitchToGameplayPage());

            LoadGamePageCommand = new RelayCommand(async () => await SwitchToLoadGamePage());

            ScoreCommand = new RelayCommand(async () => await SwitchToStatsPage());

            HoofdMenuCommand = new RelayCommand(async () => await SwitchToHoofdMenuPage());

            SettingsCommand = new RelayCommand(async () => await ToggleSettingsControl());
        }

        #endregion

        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar de newgame page.
        /// </summary>
        /// <returns>returns de newgame pagina en wacht 1 miliseconde</returns>
        public async Task SwitchToNewGamePage()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Newgame;

            await Task.Delay(1);
        }

        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar de gameplay page.
        /// </summary>
        /// <returns>returns de gameplay pagina en wacht 1 miliseconde</returns>
        public async Task SwitchToGameplayPage()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Mainwindow;
            ((MainWindow)Application.Current.MainWindow).initGameGrid();
            await Task.Delay(1);
        }

        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar loadgame page.
        /// </summary>
        /// <returns></returns>
        public async Task SwitchToLoadGamePage()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.LoadGame;

            await Task.Delay(1);
        }
        
        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar statistieken page.
        /// </summary>
        /// <returns></returns>
        public async Task SwitchToStatsPage()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Stats;

            await Task.Delay(1);
        }
        
        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar hoofdmenu page.
        /// </summary>
        /// <returns></returns>
        public async Task SwitchToHoofdMenuPage()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicatiePage.Hoofdmenu;

            await Task.Delay(1);
        }
        
        /// <summary>
        /// Set de CurrentPage die in mainwindow staat op en set hem naar hoofdmenu page.
        /// </summary>
        /// <returns></returns>
        public async Task ToggleSettingsControl()
        {
            await Task.Delay(1);
        }
    }
}
