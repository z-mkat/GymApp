using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GymApp.Views;
using Xamarin.Forms;

namespace GymApp.VModel
{
    public class MainViewModel : BaseViewModel
    {
        //public ObservableCollection<Profile> Profiles { get; private set; } = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> Profiles { get; set; }

        public MainViewModel()
        {
            Profiles = new ObservableCollection<Profile>
        {
            new Profile {Id = 1, NumberOfReps="5", NumberOfSets="6", SelectedWorkout="Tricep Extensions" }
        };
        }


        private Profile _selectedProfile;
        public Profile SelectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                if (_selectedProfile == value)
                    return;

                _selectedProfile = value;

                OnPropertyChanged();
            }
        }

        private void _PopulateList(IEnumerable<Profile> profiles)
        {
            Profiles.Clear();
            foreach (var prof in profiles)
            {
                Profiles.Add(prof);
            }
        }


        //public void AddWorkout()
        //{
        //    var mainPage = new WorkoutEntryPage(new Profile());

        //    mainPage.ProfileAdded += (source, profile) =>
        //    {
        //        Profiles.Add(profile);
        //    };
        //    //await Navigation.PushAsync(mainPage);
        //}

        public void SelectWorkout(Profile profile)
        {
            if (profile == null)
                return;

            SelectedProfile = null;
        }

        protected internal void SetProfile(Profile prof)
        {
            Profiles.Add(prof);
        }
    }
}

