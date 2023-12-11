using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourAgency_.ViewModels
{
    public class ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropeertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
