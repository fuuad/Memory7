using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// slaat input voor naam op in memory.
        /// </summary>
        public string namePlayer1;
        /// <summary>
        /// slaat input voor naam op in memory.
        /// </summary>
        public string namePlayer2;

        /// <summary>
        /// slaat input voor thema op in memory.
        /// </summary>
        public string currentTheme;
    }
}
