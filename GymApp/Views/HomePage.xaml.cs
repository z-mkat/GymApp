using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Model;
using GymApp.Services;
using GymApp.Views;
using Xamarin.Forms;

namespace GymApp
{
    public partial class HomePage : ContentPage
    {
        private NewsService _service = new NewsService();
        public static News selectedNews;

        async Task GetNews()
        {
            try
            {
                var news = await _service.GetNews();
                newsListView.ItemsSource = news;
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "Unable to load News feed.", "Ok");
                Debug.WriteLine(e);
            }
        }

        async void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            selectedNews = e.SelectedItem as News;

            newsListView.SelectedItem = null;

            await Navigation.PushAsync(new ArticlePage(selectedNews));
        }

        protected async override void OnAppearing()

        {
            await GetNews();

            base.OnAppearing();
        }

        public HomePage()
        {
            BindingContext = this;

            InitializeComponent();
        }
    }
}
