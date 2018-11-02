using PropertyChanged;
using System.ComponentModel;

namespace Memory
{
    /// <summary>
    /// waar alle viewmodels naar kijken bij verandering.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// zodra een property data veranderd
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// zet property changed naar nieuwe values.
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
