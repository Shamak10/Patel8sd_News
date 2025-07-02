namespace Patel8sd_News;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Use NavigationPage instead of Shell
        MainPage = new NavigationPage(new NewsHomePage());
    }
}
