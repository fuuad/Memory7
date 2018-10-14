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
    public class Hoofdmenu
    {
        public enum Themes { a,b,c,d};

        public Hoofdmenu()
        {

            foreach (string theme in Enum.GetNames(typeof(Themes)))
            {
                Console.WriteLine(theme);
            }
            Console.ReadKey();
        }
    }
}
