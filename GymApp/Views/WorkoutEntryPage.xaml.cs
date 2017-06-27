using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;

namespace GymApp.Views
{
    public partial class WorkoutEntryPage : ContentPage
    {
        public EventHandler<Profile> ProfileAdded;
        public EventHandler<Profile> ProfileUpdated;

        private MainPage _mainPage = new MainPage();

        public WorkoutEntryPage(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            InitializeComponent();

            BindingContext = new Profile
            {
                Id = profile.Id,
                SelectedWorkout = profile.SelectedWorkout,
                NumberOfSets = profile.NumberOfSets,
                MaxWeight = profile.MaxWeight,
                DateAndTime = profile.DateAndTime
            };
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var profile = BindingContext as Profile;

            if ((string.IsNullOrWhiteSpace(profile.SelectedWorkout)) || (string.IsNullOrWhiteSpace(profile.NumberOfSets)) || (string.IsNullOrWhiteSpace(profile.NumberOfReps)))
            {
                await DisplayAlert("Hey", "Looks like someones not working out today?", "Ok");
                return;
            }

            if (profile.Id == 0)
            {
                profile.Id = 1;

                ProfileAdded?.Invoke(this, profile);
                profile.DateAndTime = DateTime.Now.ToString("dd/MM  HH:mm");
                _mainPage.OnAdd(profile);
            }
            else
            {
                ProfileUpdated?.Invoke(this, profile);
            }
            await Navigation.PopAsync();
        }

        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            var page = new ExercisePickerPage();
            page.ExerciseType.ItemSelected += async (source, args) =>
            {
                var _profile = BindingContext as Profile;
                _profile.SelectedWorkout = args.SelectedItem.ToString();
                exerciseSelection.Text = args.SelectedItem.ToString();
                await Navigation.PopAsync();
            };

            await Navigation.PushAsync(page);
        }
    }
}
