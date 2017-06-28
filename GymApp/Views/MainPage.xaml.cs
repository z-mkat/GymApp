using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GymApp.Views;
using SQLite;
using Xamarin.Forms;

namespace GymApp
{
    public partial class MainPage : TabbedPage
    {
        private ObservableCollection<Profile> _profiles;
        private SQLiteAsyncConnection _connection;

        public MainPage()
        {
            //sets tabbed bar colour
            BarBackgroundColor = Color.FromHex("#003863");
            //sets tabbed bar icon/text colour 
            BarTextColor = Color.White;



            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }





        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Profile>();

            var profiles = await _connection.Table<Profile>().ToListAsync();
            _profiles = new ObservableCollection<Profile>(profiles);

            profileListView.ItemsSource = _profiles;

            base.OnAppearing();
        }


        async void OnAddProfileAsync(object sender, System.EventArgs e)
        {
            var mainPage = new WorkoutEntryPage(new Profile());

            mainPage.ProfileAdded += (source, profile) =>
           {
               _profiles.Add(profile);
           };

            await Navigation.PushAsync(mainPage);
        }


        async void OnRecordSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (profileListView.SelectedItem == null)
                return;

            var selectedProfile = e.SelectedItem as Profile;

            profileListView.SelectedItem = null;

            var detailPage = new WorkoutEntryPage(selectedProfile);
            detailPage.ProfileUpdated += (source, profile) =>
            {
                selectedProfile.Id = profile.Id;
                selectedProfile.SelectedWorkout = profile.SelectedWorkout;
                selectedProfile.NumberOfReps = profile.NumberOfReps;
                selectedProfile.NumberOfSets = profile.NumberOfSets;
                selectedProfile.MaxWeight = profile.MaxWeight;
            };

            await Navigation.PushAsync(detailPage);
        }

        public async void OnAdd(Profile profile)
        {

            await _connection.InsertAsync(profile);
        }


        async void OnDeleteAction(object sender, System.EventArgs e)
        {
            var profile = (sender as MenuItem).CommandParameter as Profile;

            await _connection.DeleteAsync(profile);

            _profiles.Remove(profile);

        }
    }
}
