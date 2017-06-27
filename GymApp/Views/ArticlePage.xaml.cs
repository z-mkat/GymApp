using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GymApp.Model;
using GymApp.Services;
using Xamarin.Forms;

namespace GymApp.Views
{
    public partial class ArticlePage : ContentPage
    {
        private NewsService _service = new NewsService();
        private News _news;

        public ArticlePage(News news)
        {
            if (news == null)
                throw new ArgumentNullException(nameof(news));

            _news = news;

            BindingContext = _news;

            InitializeComponent();

            var browser = new WebView();
            string webUrl = _news.webUrl;
            browser.Source = new UrlWebViewSource { Url = webUrl };

            Content = browser;
        }
    }
}
