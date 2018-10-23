using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class MainViewModel : BaseViewModel
    {
        public string Test { get; set; }

        public string Name { get; set; }
    }
}
