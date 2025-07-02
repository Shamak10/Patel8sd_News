namespace Patel8sd_News;

public partial class NewsHomePage : ContentPage
{
    public NewsHomePage()
    {
        InitializeComponent();
    }

    private async void OnCategoryClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string category = button.Text.ToLower(); // API needs lowercase category
            await Navigation.PushAsync(new NewsListPage(category));
        }
    }
}
