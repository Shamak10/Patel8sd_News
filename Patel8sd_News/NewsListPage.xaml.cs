using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Patel8sd_News.Models;

namespace Patel8sd_News
{
    public partial class NewsListPage : ContentPage
    {
        private readonly string _category;

        public NewsListPage(string category)
        {
            InitializeComponent();
            _category = category;
            CategoryLabel.Text = _category.ToUpper();
            LoadNewsAsync();
        }

        private async void LoadNewsAsync()
        {
            string apiKey = "b64dc5f8f7b3239b9965229aea0018bb";
            string url = $"https://gnews.io/api/v4/top-headlines?category={_category}&lang=en&country=us&apikey={apiKey}";

            try
            {
                using HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<GNewsResponse>(url);

                if (response?.Articles != null)
                {
                    var articlesWithImages = response.Articles
                        .Where(article => !string.IsNullOrEmpty(article.Image))
                        .ToList();
                    NewsCollectionView.ItemsSource = articlesWithImages;
                }
                else
                {
                    await DisplayAlert("No Data", "No articles found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load news: {ex.Message}", "OK");
            }
        }

        // New event handler for the tap gesture
        private async void OnArticleTapped(object sender, TappedEventArgs e)
        {
            var selectedArticle = e.Parameter as Article;
            if (selectedArticle != null)
            {
                await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
            }
        }
    }
}
