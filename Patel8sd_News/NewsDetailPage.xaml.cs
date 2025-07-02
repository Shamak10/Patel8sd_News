using Patel8sd_News.Models;

namespace Patel8sd_News;

public partial class NewsDetailPage : ContentPage
{
    public NewsDetailPage(Article article)
    {
        InitializeComponent();

        if (article != null)
        {
            Console.WriteLine($"Opening Article: {article.Title}");
        }

        BindingContext = article;
    }
}
