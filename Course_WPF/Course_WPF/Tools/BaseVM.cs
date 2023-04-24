using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Course_WPF.Tools
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Signal([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        
    }
}