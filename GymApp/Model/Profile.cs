using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace GymApp
{
    public class Profile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NumberOfReps { get; set; }
        public string NumberOfSets { get; set; }
        public string DateAndTime { get; set; }
        public string MaxWeight { get; set; }

        private string _selectedWorkout;

        [MaxLength(255)]
        public string SelectedWorkout
        {
            get { return _selectedWorkout; }
            set
            {
                if (_selectedWorkout == value)
                    return;

                _selectedWorkout = value;

                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyDateEntry = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyDateEntry));
        }


        public string FullTitle
        {
            get { return $"{SelectedWorkout}  {"Sets" + NumberOfSets} {"Reps" + NumberOfReps}"; }
        }

        public string DatetimeDetail
        {
            get { return DateAndTime; }
        }

    }
}
