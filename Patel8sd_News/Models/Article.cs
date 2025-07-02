namespace Patel8sd_News.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public Source Source { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
    }
}
