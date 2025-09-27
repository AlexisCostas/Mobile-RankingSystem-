using Microsoft.Maui.Controls;

namespace MobileRankingSystem;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
