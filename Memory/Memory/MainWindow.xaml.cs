using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }

}
