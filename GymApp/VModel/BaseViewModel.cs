using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GymApp.VModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyDateEntry = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyDateEntry));
        }

    }
}
