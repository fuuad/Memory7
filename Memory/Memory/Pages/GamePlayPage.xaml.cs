
namespace Memory
{
    /// <summary>
    /// Interaction logic for HoofdMenuPage.xaml
    /// </summary>
    public partial class GamePlayPage : BasePage<HoofdMenuViewModel>
    {
        int _rows = 4;
        int _cols = 4;
        MemoryGrid grid;


        /// <summary>
        /// standaard constructor
        /// </summary>
        public GamePlayPage()
        {
            InitializeComponent();
            initGameGrid();
        }

        /// <summary>
        /// Initialiseerd de gamegrid en de kaarten.
        /// </summary>
        public void initGameGrid()
        {
            grid = new MemoryGrid(GameGrid, _cols, _rows);
        }
    }
}
