using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PropertyChanged;
using System.Threading.Tasks;

namespace CloudManader1._0
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
