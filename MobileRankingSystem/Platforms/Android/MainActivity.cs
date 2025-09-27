using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MobileRankingSystem;

[Activity(Label = "Mobile Ranking System", Theme = "@style/Maui.SplashTheme", MainLauncher = true, Exported = true,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                                 ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density |
                                 ConfigChanges.LayoutDirection)]
public class MainActivity : MauiAppCompatActivity
{
}
