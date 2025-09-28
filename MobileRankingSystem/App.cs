using Microsoft.Maui.Controls;

namespace MobileRankingSystem;

public sealed class App : Application
{
    public App()
    {
        Resources = BuildResourceDictionary();
        MainPage = new NavigationPage(new MainPage());
    }

    private static ResourceDictionary BuildResourceDictionary()
    {
        var resources = new ResourceDictionary
        {
            { "PrimaryColor", Color.FromArgb("#2563EB") },
            { "SecondaryColor", Color.FromArgb("#4F46E5") },
            { "PageBackgroundColor", Colors.White },
            { "CardBackgroundColor", Color.FromArgb("#EEF2FF") },
            { "PrimaryTextColor", Color.FromArgb("#1F2937") },
            { "SecondaryTextColor", Color.FromArgb("#4B5563") }
        };

        resources.Add(new Style(typeof(ContentPage))
        {
            Setters =
            {
                new Setter { Property = VisualElement.BackgroundColorProperty, Value = resources["PageBackgroundColor"] }
            }
        });

        resources.Add(new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                new Setter { Property = Label.FontFamilyProperty, Value = "OpenSansRegular" }
            }
        });

        resources.Add("SectionHeader", new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.FontSizeProperty, Value = 24d },
                new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                new Setter { Property = Label.FontFamilyProperty, Value = "OpenSansSemibold" }
            }
        });

        resources.Add("SubsectionHeader", new Style(typeof(Label))
        {
            Setters =
            {
                new Setter { Property = Label.FontSizeProperty, Value = 18d },
                new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                new Setter { Property = Label.FontFamilyProperty, Value = "OpenSansSemibold" }
            }
        });

        resources.Add("RankingCard", new Style(typeof(Frame))
        {
            Setters =
            {
                new Setter { Property = Frame.BackgroundColorProperty, Value = resources["CardBackgroundColor"] },
                new Setter { Property = Frame.CornerRadiusProperty, Value = 12f },
                new Setter { Property = Frame.HasShadowProperty, Value = false },
                new Setter { Property = Frame.PaddingProperty, Value = new Thickness(16) }
            }
        });

        return resources;
    }
}
